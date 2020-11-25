read a
git branch $a
git checkout $a
git add .
git commit -m "[Apoorva] Refactor . Refactored query with new table structure"
git push origin $a
git checkout master
git merge $a
git push origin master --force
