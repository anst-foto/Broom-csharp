#!/bin/bash
# Copyright (c) 2013 Martin Seeler
# SPDX-License-Identifier: MIT
# https://github.com/MartinSeeler/auto-changelog-hook

#
# chmod +x post-commit
# cp post-commit ${YOUR_GIT_PROJECT_PATH}/.git/hooks
#

set -eu

OUTPUT_FILE=CHANGELOG.auto.md

git --no-pager log --no-merges --format="### %s%d%n>%aD%n%n>Author: %aN (%aE)%n%n>Commiter: %cN (%cE)%n%n%b%n%N%n" > $OUTPUT_FILE

# prevent recursion!
# since a 'commit --amend' will trigger the post-commit script again
# we have to check if the changelog file has changed or not
res=$(git status --porcelain | grep -c ".\$OUTPUT_FILE$")
if [ "$res" -gt 0 ]; then
  git add $OUTPUT_FILE
  git commit --amend
  echo "Populated Changelog in $OUTPUT_FILE"
fi
