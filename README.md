# ASP.NET Core Pragmatic Architecture
The purpose of this repository is to provide practical examples on how to build morden ASP.NET Core applications using a pragmatic approach.

It takes inspiration from various well known architectural patterns such as Clean Architecture, Hexagonal Architecture, and Domain-Driven Design, but focuses on simplicity and adaptability to change.

# Is this yet another cookie-cutter example clean architecture project?
Yes and no.

The principles and patterns that work are certainly there, but the goal is to provide ideas on how to approach code organization & architecture rather than a rigid structure to follow.

The answers to architectural questions are always "it depends" - there are no silver bullets. 

# Principles
## The right amount of simplicity
In new projects, there's often a tendency to do one of two things:
* Over-engineer the solution with unnecessary abstractions (which can include clean architecture patterns)
* Taking the shortest path to a working solution, disregarding maintainability

Both problems can even coexist in the same project, in different areas of the codebase.

Choosing the right trade-offs is often a question of framing the problem in the way that best suits the current context:
* What are the most likely changes?
* What is the level of expertise of the team?
* What are the most critical components of the system?
* What are the non-functional requirements?
* What is the expected lifetime of the project?

Thinking about these questions combined with a good overall understanding of software architecture principles can help find the right balance and more importantly, easily adapt the architecture when things inevitably change.

## The only constant is change
The architecture of a software system should be constantly be questioned and new changes should guide where the architecture needs to evolve

## Question the basics
Established patterns are good starting points. They give a team or organization a common language and understanding of how to structure code.
This is why for most use cases a standard, a cookie-cutter clean architecture approach works well, but at some point cracks start to show and we must go back to first principles.

This idea is goes hand in hand with finding the right amount of simplicity - somethimes doing something as simple as breaking down abstractions or merging layers can lead to a better result.

# Assumptions & implementation ideas (WIP)
## A monorepo is better
The disadvantages of multiple repositories far outweigh their perceived advantages. That being said, using a monorepo means that dev tooling should have a higher priority in the software development lifecycle.

## One version to rule them all
Using the same version of dependencies across all projects in the monorepo is a must to avoid dependency hell.

## Share code wisely
Cross-cutting concerns and shared components are good, only when they actually provide value.
Any shared components should be flexible enough to:
* Evolve independently from the consumers
* Be easily replaced when needed

In addition to this, the right way to share code should be carefully evaluated.
One useful but less commonly used pattern is to use linked Files in .NET projects to share code between multiple projects without necessarily creating a separate project (with all that it entails).

## Don't fight the framework
ASP.NET Core is pretty good nowadays. It's flexible and it mostly gets out of your way.
There's usually some established patterns to follow when working with the framework, and deviating from them should be a conscious decision.

## ... but don't be a slave to it
When it does get in the way, plugging in a new component or replacing a part of the framework should be easy enough.