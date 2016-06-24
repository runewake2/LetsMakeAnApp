using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emotible.Model;
using Emotible.ViewModels;

namespace Emotible.Layout
{
    public class LayoutController
    {
        private const int _fillerEmoteId = -1337;

        public ObservableCollection<IEmoteViewModel> BuildCollection()
        {
            using (var db = new EmoteContext())
            {
                IQueryable<EmoteModel> availableEmotes = db.Emotes;
                availableEmotes = ApplyFilter(availableEmotes);
                availableEmotes = ApplyOrdering(availableEmotes);
                var emotes = new ObservableCollection<IEmoteViewModel>();
                foreach (var view in availableEmotes)
                {
                    emotes.Add(new EmoteViewModel()
                    {
                        Id = view.Id,
                        Name = view.Name,
                        Text = view.Content,
                        Height = view.Height,
                        Width = view.Width,
                    });
                }
                return emotes;
            }
        }

        public void UpdateCollectionView(ObservableCollection<IEmoteViewModel> emotes, int columns)
        {
            RemoveFillerEmotes(emotes);
        }

        private void RemoveFillerEmotes(ObservableCollection<IEmoteViewModel> emotes)
        {
            List<int> invalidIndices = new List<int>();
            for (int i = 0; i < emotes.Count; ++i)
            {
                if (emotes[i].Id == _fillerEmoteId)
                {
                    invalidIndices.Add(i);
                }
            }

            foreach (var index in invalidIndices.OrderByDescending(i => i))
            {
                emotes.RemoveAt(index);
            }
        }

        private static IQueryable<EmoteModel> ApplyFilter(IQueryable<EmoteModel> emotes)
        {
            return emotes; // This provides the ability to perform filtering later
        }

        private static IQueryable<EmoteModel> ApplyOrdering(IQueryable<EmoteModel> emotes)
        {
            // Order emotes by the number of times they have been used so more used emotes are shown earlier
            return emotes.OrderByDescending(model => model.TimesUsed);
        }
    }
}
