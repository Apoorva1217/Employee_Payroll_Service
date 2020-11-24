read a
git branch $a
git checkout $a
git add .
git commit -m "[Apoorva] Add . Ability to update the salary i.e. the base pay for Employee Terisa to 3000000.00 and sync it with Database using ADO.NET ConnectionString"
git push origin $a
git checkout master
git merge $a
git push origin master --force
