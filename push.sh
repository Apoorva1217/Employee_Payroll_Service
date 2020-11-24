read a
git branch $a
git checkout $a
git add .
git commit -m "[Apoorva] Add . Ability to find sum, average, min, max and number of male and female employees"
git push origin $a
git checkout master
git merge $a
git push origin master --force
