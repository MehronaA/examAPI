create table users(
id serial primary key,
userName varchar(50) not null,
email varchar(150) not null,
passwordHash varchar(256) not null,
bio varchar,
createdAt TIMESTAMP  not null
);
create table articles(
id serial primary key,
userId int references users(id),
title varchar(255) not null,
content varchar not null,
description varchar(500),
createdAt TIMESTAMP  not null,
status varchar(20) check(status in ('draft','published'))
);
create table comments(
id serial primary key,
articleId int references articles(id),
userId int references users(id),
content varchar not null,
createdAt TIMESTAMP  not null
);
create table claps(
id serial primary key,
articleId int references articles(id),
userId int references users(id),
count int not null,
createdAt TIMESTAMP  not null
);
INSERT INTO users (userName, email, passwordHash, bio, createdAt) VALUES
('john_doe', 'john@example.com', 'hash1', 'Software Developer', '2024-01-01'),
('jane_smith', 'jane@example.com', 'hash2', 'Content Writer', '2024-01-02'),
('bob_wilson', 'bob@example.com', 'hash3', 'Tech Enthusiast', '2024-01-03'),
('alice_brown', 'alice@example.com', 'hash4', 'UI Designer', '2024-01-04'),
('mike_jones', 'mike@example.com', 'hash5', 'Product Manager', '2024-01-05'),
('sarah_davis', 'sarah@example.com', 'hash6', 'Tech Blogger', '2024-01-06'),
('tom_miller', 'tom@example.com', 'hash7', 'Student', '2024-01-07'),
('emma_wilson', 'emma@example.com', 'hash8', 'Software Engineer', '2024-01-08'),
('james_taylor', 'james@example.com', 'hash9', 'Web Developer', '2024-01-09'),
('lisa_anderson', 'lisa@example.com', 'hash10', 'Data Scientist', '2024-01-10');

INSERT INTO articles (userId, title, content, description, createdAt, status) VALUES
(1, 'Getting Started with C#', 'Content 1', 'Basic C# tutorial', '2024-01-15', 'published'),
(2, 'Web Development Tips', 'Content 2', 'Essential web dev tips', '2024-01-16', 'published'),
(3, 'SQL Basics', 'Content 3', 'Introduction to SQL', '2024-01-17', 'published'),
(4, 'UI Design Principles', 'Content 4', 'Basic UI concepts', '2024-01-18', 'published'),
(5, 'Product Management 101', 'Content 5', 'PM basics', '2024-01-19', 'published'),
(1, 'Advanced C# Topics', 'Content 6', 'Advanced tutorial', '2024-01-20', 'draft'),
(2, 'Frontend Frameworks', 'Content 7', 'Framework comparison', '2024-01-21', 'published'),
(3, 'Database Design', 'Content 8', 'DB design principles', '2024-01-22', 'published'),
(4, 'UX Best Practices', 'Content 9', 'UX guidelines', '2024-01-23', 'published'),
(5, 'Agile Methodology', 'Content 10', 'Agile basics', '2024-01-24', 'published');

INSERT INTO comments (articleId, userId, content, createdAt) VALUES
(1, 2, 'Great article!', '2024-01-25'),
(1, 3, 'Very helpful', '2024-01-25'),
(2, 1, 'Nice tips', '2024-01-26'),
(2, 4, 'Useful info', '2024-01-26'),
(3, 5, 'Well explained', '2024-01-27'),
(3, 1, 'Thanks for sharing', '2024-01-27'),
(4, 2, 'Interesting points', '2024-01-28'),
(4, 3, 'Good examples', '2024-01-28'),
(5, 4, 'Clear explanation', '2024-01-29'),
(5, 5, 'Very informative', '2024-01-29');


INSERT INTO claps (articleId, userId, count, createdAt) VALUES
(1, 2, 5, '2024-01-25'),
(1, 3, 3, '2024-01-25'),
(2, 1, 4, '2024-01-26'),
(2, 4, 2, '2024-01-26'),
(3, 5, 5, '2024-01-27'),
(3, 1, 3, '2024-01-27'),
(4, 2, 4, '2024-01-28'),
(4, 3, 2, '2024-01-28'),
(5, 4, 5, '2024-01-29'),
(5, 5, 3, '2024-01-29');