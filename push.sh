read a
git branch $a
git checkout $a
git add .
git commit -m "[Apoorva] Add . Implement the complete ER diagram in the database"
git push origin $a
git checkout master
git merge $a
git push origin master --force
