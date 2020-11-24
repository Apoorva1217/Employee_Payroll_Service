read a
git branch $a
git checkout $a
git add .
git commit -m "[Apoorva] Add . Ability to retrieve all employees who have joined in a particular data range from the payroll service database"
git push origin $a
git checkout master
git merge $a
git push origin master --force
