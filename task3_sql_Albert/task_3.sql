CREATE DATABASE [ALBERTTASK_01]
GO

USE [ALBERTTASK_01]
GO

CREATE TABLE position (
    id INT PRIMARY KEY,
    name VARCHAR(50),
    rate DECIMAL(10,2)
);

-- Insert initial data into position table
INSERT INTO position (id, name, rate)
VALUES
    (1, 'Manager', 500),
    (2, 'Developer', 540),
    (3, 'QA Engineer', 652),
    (4, 'Designer', 510),
    (5, 'Business Analyst', 530);

CREATE TABLE project (
    id INT PRIMARY KEY,
    name VARCHAR(50),
    max_sum_rate DECIMAL(10,2)
);

-- Insert initial data into project table
INSERT INTO project (id, name, max_sum_rate)
VALUES
    (1, 'Project 1', 5000.00),
    (2, 'Project 2', 7500.00),
    (3, 'Project 3', 10000.00),
    (4, 'Project 4', 15000.00),
    (5, 'Project 5', 20000.00);

CREATE TABLE employee (
    id INT PRIMARY KEY,
    first_name VARCHAR(50),
    last_name VARCHAR(50),
    position_id INT,
    project_id INT,
    CONSTRAINT FK_employee_position FOREIGN KEY (position_id) REFERENCES position(id), 
    CONSTRAINT FK_employee_project FOREIGN KEY (project_id) REFERENCES project(id)
);

-- Insert initial data into employee table
INSERT INTO employee (id, first_name, last_name, position_id, project_id)
VALUES
    (1, 'John', 'Doe', 1, 1),
    (2, 'Jane', 'Doe', 2, 2),
    (3, 'Bob', 'Smith', 3, 3),
    (4, 'Alice', 'Johnson', 4, 4),
    (5, 'Tom', 'Lee', 5, 5);

CREATE TABLE equipment (
    id INT PRIMARY KEY,
    name VARCHAR(50),
    price DECIMAL(10,2),
    user_id INT,
    FOREIGN KEY (id) REFERENCES employee(id)
);

-- Insert initial data into equipment table
INSERT INTO equipment (id, name, price, user_id)
VALUES
    (1, 'Laptop', 1200.00, 1),
    (2, 'Monitor', 350.00, 2),
    (3, 'Keyboard', 800.00, 3),
    (4, 'Mouse', 500.00, 4),
    (5, 'Headphones', 1000.00, 5);

CREATE TABLE vacancies (
    id INT PRIMARY KEY,
    position_id INT,
    FOREIGN KEY (position_id) REFERENCES position(id)
);

INSERT INTO vacancies (id, position_id)
VALUES
    (1, 2),
    (2, 3),
    (3, 4),
    (4, 5),
    (5, 1);

select * from employee


--Request. 1--
SELECT employee.*
FROM employee
LEFT JOIN project ON employee.project_id = project.id
WHERE project.id IS NULL;

--Request. 2--
SELECT project.name
FROM project
INNER JOIN (
    SELECT employee.project_id, SUM(position.rate) AS monthly_salary
    FROM employee
    INNER JOIN position ON employee.position_id = position.id
    GROUP BY employee.project_id
) AS salaries ON project.id = salaries.project_id
WHERE salaries.monthly_salary > project.max_sum_rate;

--Request. 3--

SELECT CONCAT(employee.first_name, ' ', employee.last_name) AS employee_name, project.name AS project_name
FROM employee
INNER JOIN project ON employee.project_id = project.id
INNER JOIN position ON employee.position_id = position.id
GROUP BY CONCAT(employee.first_name, ' ', employee.last_name), project.name, project.max_sum_rate
HAVING SUM(position.rate) > project.max_sum_rate/12;

--Request. 4.--
SELECT 
    employee.first_name, 
    employee.last_name, 
    project.name AS project_name,
    ((SUM(rate) + SUM(price))/12) AS monthly_expenses,
    (project.max_sum_rate - ((SUM(rate) + SUM(price))/12)) AS budget_diff
FROM 
    employee  
    INNER JOIN project project ON employee.project_id = project.id
    INNER JOIN position position ON employee.position_id = position.id
    INNER JOIN equipment equipment ON employee.id = equipment.user_id
GROUP BY 
    employee.id, 
    employee.first_name, 
    employee.last_name, 
    project.name, 
    project.max_sum_rate
HAVING 
    ((SUM(rate) + SUM(price))/12) > project.max_sum_rate;