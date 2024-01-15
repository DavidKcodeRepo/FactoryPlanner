# Factory Planner - Readme

Factory planner is a tool for playing the game Satisfactory- an automation and base-building game . It solves the challenge of planning a complex factory with several production stages and machines.

![Factory Planner UI](https://i.imgur.com/izmU7K1.png)

A list of game-recipes is pre-populated from which a user makes selections to edit the resulting output and check the balance of intermediate products. 

Essentially, the program is a product sum calculating data grids with dynamic column row filtering based on the users needs. 

This is a conceptually simple problem; but the number of recipes, combinations of inputs, alternate recipe pathways, biproduct-handling and in-game time-to-build  concerns of the game create complexity that justifies the need for a planning tool.

## Features




 - automatic filtering for ingredients based on recipe search
 - machine-lookup to find recipes
 - conditional formatting for glancing 

## Implementation

 - Satisfactory Planner is implemented in a c# winforms application
   using MVVM architecture.  
 - The recipe table, and headings for user
   selections  results are loaded upon startup from a csv file
   configured in the app.config file. 
 - This application was authored from the C# winforms application template in visual studio using only my own knowledge & ability to research documentation; this is my own work and not a reskin of another online tutorial.

## 


```
```mermaid
graph LR
A[Load Project] -->B((User selects <br> recipes ))-->C((Output recalc <br> balances))-->B
B-->D((Final Product))
<!--stackedit_data:
eyJoaXN0b3J5IjpbLTg1OTc5MTUxMCwtNjIwMjE2Nzk1LC0zMz
M4Njk2ODFdfQ==
-->