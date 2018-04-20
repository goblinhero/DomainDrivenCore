# DomainDrivenCore
One way of doing domain driven business application in .NET core using NHibernate and custom rule engines. UI-agnostic, so use whatever floats your boat on the UI end. This is about building the API and the domain.

### TL;DR
Want to build a CRUD application and heard about DDD? This is the place for you. There are no silver bullets here, but maybe a few nuggets of convinience.

## Guiding principles
This framework is based on the thoughts contained in Domain Driven Design by Erick J. Evans and the Onion Architecture by Jeffrey Palermo. If you are not familiar with those two, go read up on them before attempting to use this framework. They are much smarter than I and can explain it far better.

The idea is to keep the domain free of any infrastructure concerns and keep the leaky abstractions to a minimum. Also, CQRS (Command-Query Responsibility Separation) is paramount. This means that no business entity will leave the backend. Instead, representations (DataTransfer Objects) will be sent over the wire and will be used to create, alter and delete entities inside of a Unit of Work (the ISession in NHibernate).

## Why on earth NHibernate and not Entity Framework?
There are a few reasons:
* I started coding before Entity Framework came out and can't be bothered to change
* That's it.
