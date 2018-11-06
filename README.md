# fightinggame

### Getting Started
Go into command line. Move to the folder/directory you want to have download the repo to. 
Then, type `git clone https://github.com/djlalo08/fightinggame`.
Should be good to go from there.

### Useful git commands
+ `git status`
Lets you see which files are staged for commits. Also shows you which files are untracked or modified. 
+ `git log`
Lets you see all of the changes that have been made so far in the current git branch.
+ `git add`
Stages a file/folder for committing. After using this, use `git status` to see the changes you have added in green.
+ `git commit`
Essentially saves your changes. They can now be pushed to the general repo.
The usual command that you will use will be `git commit -m "[MEANINGFUL COMMIT MESSAGE]"` where the stuff in
parentheses will be a meaningful, relevant, and succint message describing the changes that you made.
+ `git push`
This sends your commit to the repo. Everyone will now have access to your changes. 
**Note**: You don't have to push just a single commit.You can have multiple commits, 
maybe for various things you done/added, and then push them all at the same time.
The general command you'll be using is `git push -u origin master`. Actual professionals would probably get mad at us for not using git 
properly for version control, but we're not professionals so this is k. 
