# Deletes the apps local database. Use this to reseed the database or clear out the db for a fresh install.
$pathToDb = $env:LOCALAPPDATA + "\Packages\2db51aeb-1b79-4cb2-b8ef-0f6a48a674cf_cjk1afta2ddfe\LocalState\emotedb.db"
Remove-Item $pathToDb