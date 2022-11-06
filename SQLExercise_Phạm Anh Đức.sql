1.
SELECT * FROM employees WHERE last_name = 'Zlotkey'
SELECT * FROM employees WHERE department_id = 80 and last_name != 'Zlotkey'

SELECT e1.last_name, e1.hire_date FROM employees e1
inner join employees e2 on e1.department_id = e2.department_id
WHERE e2.last_name='Zlotkey' and e1.last_name != 'Zlotkey'

SELECT AVG(salary) FROM employees 

SELECT employee_id, last_name, salary FROM employees WHERE salary > (SELECT AVG(salary)FROM employees) ORDER BY salary DESC

SELECT e1.last_name, e1.department_id, e1.job_id FROM employees e1
INNER JOIN departments e2 on e1.department_id = e2.department_id
INNER JOIN locations e3 on e3.location_id = e2.location_id
WHERE e3.city = 'Seattle'

SELECT e1.employee_id, e2.department_name FROM employees e1
LEFT JOIN departments e2 on e1.department_id = e2.department_id

2.
select AVG(salary) from employees
select employee_id, last_name, salary from employees where salary>(select AVG(salary) from employees) order by salary DESC

3.
select e1.employee_id, e1.last_name from employees e1
inner join employees e2 on e1.department_id =  e2.department_id
where e2.last_name like '%u%'

4.
select e1.last_name, e1.department_id, e1.job_id from employees e1 
join departments e2 on e1.department_id= e2.department_id
join locations e3  on e2.location_id = e3.location_id
where e3.city='Seattle'

5.
select last_name, salary from employees
where manager_id in (select employee_id from employees where last_name = 'King') 

6.
Select e1.department_id, e1.last_name, e1.job_id from employees e1
join departments e2 on e1.department_id = e2.department_id
where e2.department_name = 'Executive'

7.
select employee_id, last_name, salary from employees where salary > (select AVG(salary) from employees)
union
select e1.employee_id, e1.last_name, e1.salary from employees e1
inner join employees e2 on e1.department_id =  e2.department_id
where e2.last_name like '%u%'

8. 
select MAX(salary) AS 'Maximum', MIN(salary) AS 'Minimum', ROUND(SUM(salary),0) AS 'Sum', ROUND(AVG(salary),0) AS 'Average' from employees

9.
select last_name AS 'Last name', LEN(last_name) AS 'Length'from employees
where last_name like 'J%' OR last_name like 'A%' or last_name like 'M%' order by last_name

10.
select employee_id, last_name, salary, salary*1.155 AS 'New Salary' from employees

11.
--c1
select e1.last_name, e1.department_id, e2.department_name from employees e1
join departments e2 on e1.department_id = e2.department_id 
--c2
select last_name, department_id, CHAR(null) from employees 
union
select CHAR(null) ,department_id, department_name from departments

12.
select e1.employee_id, e1.last_name from employees e1
join employees e2 on e2.manager_id = e1.employee_id 
where e1.hire_date > e2.hire_date
union
select e1.employee_id, e1.last_name from employees e1
join departments e2 on e1.department_id =  e2.department_id
join locations e3 on e3.location_id = e2.location_id
where e3.city = 'Toronto'