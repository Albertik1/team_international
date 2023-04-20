CREATE TABLE projects (
    project_id INT PRIMARY KEY,
    project_name VARCHAR(50) NOT NULL,
    project_description VARCHAR(100) NOT NULL,
    start_date DATE NOT NULL,
    end_date DATE NOT NULL
);

INSERT INTO projects (project_id, project_name, project_description, start_date, end_date) 
VALUES 
    (1, 'Project A', 'This is project A', '2022-01-01', '2022-06-30'),
    (2, 'Project B', 'This is project B', '2022-02-01', '2022-07-31'),
    (3, 'Project C', 'This is project C', '2022-03-01', '2022-08-31'),
    (4, 'Project D', 'This is project D', '2022-04-01', '2022-09-30'),
    (5, 'Project E', 'This is project E', '2022-05-01', '2022-10-31');
