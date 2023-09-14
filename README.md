# Who At X?

A tool for organisations and businesses to use internally, to help them find the right person to talk to about a particular topic, and to equip them to best communicate with them. In terms of naming, 'X' is your organisation or business. For example, a business called 'Acme' would call this tool 'Who At Acme?'.

Each member/employee has a personal profile, including details like:

- how people like to be talked to
- how to be praised
- pronouns
- name pronounciation
- etc.

It also covers key professional information like:

- what your areas of knowledge are
- what projects you work on
- what team you're on
- your working hours
- your time zone
- etc.

This is plugged in to an LLM (GPT) with search capability, so you can find the people you are looking for who have knowledge on a particular thing by asking it a question, with it responding the best matches and providing links to their profiles to enable you to approach them in the way they like to be approached.

## Possible future features

- linking to calendars to make it clear if people are available or away
- embedding into Jira to make it easy to assign the right people to the right tickets

## Local development instructions

1. Clone the repo
2. Run `dotnet tool install --global dotnet-ef` to install the Entity Framework CLI if you haven't already
3. Within the WhoAtX folder, run `dotnet ef migrations add InitialCreate` then `dotnet ef database update` to create the database
