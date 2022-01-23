CREATE TABLE users (
	id VARCHAR PRIMARY KEY,
	email VARCHAR
);

CREATE TABLE households (
	id VARCHAR PRIMARY KEY,
	owner_id VARCHAR REFERENCES users(id)
);

CREATE TABLE household_members (
	household_id VARCHAR REFERENCES households(id),
	member_id VARCHAR REFERENCES users(id)
);

CREATE TABLE frequency__scheduled_chores (
	id INTEGER PRIMARY KEY,
	description VARCHAR
);

CREATE TABLE scheduled_chores (
	id VARCHAR PRIMARY KEY,
	household_id VARCHAR REFERENCES households(id),
	assignee_id VARCHAR REFERENCES users(id),
	name VARCHAR,
	difficulty INTEGER,
	frequency INTEGER REFERENCES frequency__scheduled_chores(id)
);

CREATE TABLE chore_events (
	id VARCHAR PRIMARY KEY,
	scheduled_chore_id VARCHAR REFERENCES scheduled_chores(id),
	completed_datetime TIMESTAMP WITH TIME ZONE
);