-- Create a database
create database Payroll_ServiceDB;
-- View database
use Payroll_ServiceDB;
select DB_NAME();

-- Create Employee Table
create table Employee
(
Emp_ID int identity(1,1),
Emp_Name varchar(25) not null,
Gender char not null,
Company_Name varchar(20) not null,
Dept_Name varchar(25) not null,
Phone_No varchar(15) not null,
Address varchar(20) not null,
start_date date not null,
BasicPay money not null,
Deduction money not null,
TaxablePay money not null,
IncomeTax money not null,
NetPay money not null,
PRIMARY KEY (Emp_ID)
);

-- Inserting data into Employees table
insert into Employee values
('Sherlock','M','Capgemini','Developer' ,'7413454354' ,'Hyderabad','2018-10-03',120000,10000,110000,10000,100000),
('Isabella','F','Accenture','Logistics' ,'8985665656' ,'Bangalore','2019-08-28',220000,10000,210000,10000,200000),
('Lawrence','M','Microsoft','Developer' ,'9189898765' ,'Amaravati','2020-04-05',320000,10000,310000,10000,300000),
('Jonathan','M','Capgemini','Accounting','8339898765' ,'New Delhi','2016-11-05',150000,10000,140000,10000,130000),
('Benedict','M','TataElxsi','Marketing' ,'6300898765' ,'Amaravati','2017-04-15',140000,20000,120000,10000,110000),
('Benedict','M','Microsoft','Logistics' ,'6300898765' ,'Bangalore','2017-04-15',120000,10000,110000,10000,100000),
('Benedict','M','TataElxsi','Marketing' ,'6300898765' ,'New Delhi','2017-04-15',320000,10000,310000,10000,300000),
('Jennifer','F','Accenture','Accounting','7656898765' ,'Hyderabad','2018-07-25',220000,10000,210000,10000,200000);

-- View Employee table
select * from Employee;