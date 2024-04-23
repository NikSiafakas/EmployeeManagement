import React, { Component } from 'react';
import { variables } from './Variables';
import { NavLink } from 'react-router-dom';

export class Employees extends Component {

    constructor(props) {
        super(props);
        this.state = {
            skills: [],
            employees: [],
            employeesNameFilter: "",
            employeesSurnameFilter: "",
            employeesSkillsetFilter: 0,
            employeesWithoutFilter: []
        }
    }
      
    render() {
        const { employees, skills } = this.state;
        return (
            <div>
                <NavLink className='btn btn-primary m-2 float-end' to="/Employee" onClick={() => this.setupEmployeePage(-1)}>Add Employee</NavLink>

                <table className='table table-striped'>
                    <thead>
                        <tr>
                            <th><input id='EmployeeNameFilter' className='form-control m-2' onChange={this.changeEmployeeNameFilter} placeholder='Filter'/></th>
                            <th><input id='EmployeeSurnameFilter' className='form-control m-2' onChange={this.changeEmployeeSurnameFilter} placeholder='Filter'/></th>
                            <th><select className="form-select m-2" style={{margin: 8, paddingTop: 6, paddingRight: 12, paddingBottom: 6, paddingLeft: 12}}
                                id="EmployeeSkillsetFilter" onChange={() => this.changeEmployeeSkillsetFilter()}>
                                <option defaultValue>Filter by Skill</option>
                                {skills.map(a => (
                                <option key={a.Id} value={a.Id}>{a.Name}</option>))}
                                </select>
                            </th>
                        </tr>
                        <tr>
                            <th>
                                <div className='d-flex flex-row'>
                                    <div style={{paddingTop: 5, paddingRight: 6}}>Name</div>
                                    <button type='button' className='btn' style={{padding: 3}} onClick={() => this.sortEmployees('Name', true)}>
                                    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" className="bi bi-caret-up-fill" viewBox="0 0 16 16">
                                    <path d="m7.247 4.86-4.796 5.481c-.566.647-.106 1.659.753 1.659h9.592a1 1 0 0 0 .753-1.659l-4.796-5.48a1 1 0 0 0-1.506 0z"/>
                                    </svg>
                                    </button>
                                    <button type='button' className='btn' style={{padding: 3}} onClick={() => this.sortEmployees('Name', false)}>
                                    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" className="bi bi-caret-down-fill" viewBox="0 0 16 16">
                                    <path d="M7.247 11.14 2.451 5.658C1.885 5.013 2.345 4 3.204 4h9.592a1 1 0 0 1 .753 1.659l-4.796 5.48a1 1 0 0 1-1.506 0z"/>
                                    </svg></button>
                                </div>
                            </th>
                            <th>
                                <div className='d-flex flex-row'>
                                    <div style={{paddingTop: 5, paddingRight: 6}}>Surname</div>
                                    <button type='button' className='btn' style={{padding: 3}} onClick={() => this.sortEmployees('Surname', true)}>
                                    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" className="bi bi-caret-up-fill" viewBox="0 0 16 16">
                                    <path d="m7.247 4.86-4.796 5.481c-.566.647-.106 1.659.753 1.659h9.592a1 1 0 0 0 .753-1.659l-4.796-5.48a1 1 0 0 0-1.506 0z"/>
                                    </svg></button>
                                    <button type='button' className='btn' style={{padding: 3}} onClick={() => this.sortEmployees('Surname', false)}>
                                    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" className="bi bi-caret-down-fill" viewBox="0 0 16 16">
                                    <path d="M7.247 11.14 2.451 5.658C1.885 5.013 2.345 4 3.204 4h9.592a1 1 0 0 1 .753 1.659l-4.796 5.48a1 1 0 0 1-1.506 0z"/>
                                    </svg></button>
                                </div>
                            </th>
                            <th>Email</th>
                            <th>
                                <div className='d-flex flex-row'>
                                    <div style={{paddingTop: 5, paddingRight: 6}}>Hired</div>
                                    <button type='button' className='btn' style={{padding: 3}} onClick={() => this.sortEmployees('Hired', true)}>
                                    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" className="bi bi-caret-up-fill" viewBox="0 0 16 16">
                                    <path d="m7.247 4.86-4.796 5.481c-.566.647-.106 1.659.753 1.659h9.592a1 1 0 0 0 .753-1.659l-4.796-5.48a1 1 0 0 0-1.506 0z"/>
                                    </svg></button>
                                    <button type='button' className='btn' style={{padding: 3}} onClick={() => this.sortEmployees('Hired', false)}>
                                    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" className="bi bi-caret-down-fill" viewBox="0 0 16 16">
                                    <path d="M7.247 11.14 2.451 5.658C1.885 5.013 2.345 4 3.204 4h9.592a1 1 0 0 1 .753 1.659l-4.796 5.48a1 1 0 0 1-1.506 0z"/>
                                    </svg></button>
                                </div>
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        {employees.map(a =>
                        <tr key={a.Id}>
                            <td>{a.Name}</td>
                            <td>{a.Surname}</td>
                            <td>{a.Email}</td>
                            <td>{new Date(a.Hired).toISOString().split('T')[0]}</td>
                            <td><NavLink className='btn btn-light mr-1' to="/Employee" onClick={() => this.setupEmployeePage(a.Id)}>
                            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" className="bi bi-info-square" viewBox="0 0 16 16">
                            <path d="M14 1a1 1 0 0 1 1 1v12a1 1 0 0 1-1 1H2a1 1 0 0 1-1-1V2a1 1 0 0 1 1-1zM2 0a2 2 0 0 0-2 2v12a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V2a2 2 0 0 0-2-2z"/>
                            <path d="m8.93 6.588-2.29.287-.082.38.45.083c.294.07.352.176.288.469l-.738 3.468c-.194.897.105 1.319.808 1.319.545 0 1.178-.252 1.465-.598l.088-.416c-.2.176-.492.246-.686.246-.275 0-.375-.193-.304-.533zM9 4.5a1 1 0 1 1-2 0 1 1 0 0 1 2 0"/>
                            </svg></NavLink></td>
                        </tr>
                        )}
                    </tbody>
                </table>

            </div>
        )
    }
    
    componentDidMount() {
        this.refreshEmployees();
        this.refreshSkills();
    }

    changeEmployeeNameFilter = (e) => {
        this.state.employeesNameFilter = e.target.value;
        this.filterEmployees();
    }
    changeEmployeeSurnameFilter = (e) => {
        this.state.employeesSurnameFilter = e.target.value;
        this.filterEmployees();
    }
    changeEmployeeSkillsetFilter() {
        let skillSelected = 0;
        let employeeSkillsetFilter = document.getElementById("EmployeeSkillsetFilter");
        if (employeeSkillsetFilter.value > 0) {
            skillSelected = parseInt(employeeSkillsetFilter.value);
        }
        this.state.employeesSkillsetFilter = skillSelected;
        this.filterEmployees();
    }
    filterEmployees() {
        let employeesNameFilter = this.state.employeesNameFilter;
        let employeesSurnameFilter = this.state.employeesSurnameFilter;
        let employeesSkillsetFilter = this.state.employeesSkillsetFilter;
        let filteredData = this.state.employeesWithoutFilter.filter(
            function(emp) {
                return emp.Name.trim().toLowerCase().includes(employeesNameFilter.trim().toLowerCase()) &&
                    emp.Surname.trim().toLowerCase().includes(employeesSurnameFilter.trim().toLowerCase()) &&
                    ((employeesSkillsetFilter > 0) ? emp.Skillset.includes(employeesSkillsetFilter) : true);
            }
        );
        this.setState({ employees: filteredData });
    }

    sortEmployees(prop, asc) {
        document.getElementById('EmployeeNameFilter').value = "";
        this.state.employeesNameFilter = "";
        document.getElementById('EmployeeSurnameFilter').value = "";
        this.state.employeesSurnameFilter = "";

        let sortedData = this.state.employeesWithoutFilter.sort(
            function(a,b) {
                if (asc) { return (a[prop] > b[prop]) ? 1 : ((a[prop] < b[prop]) ? -1 : 0); }
                return (b[prop] > a[prop]) ? 1 : ((b[prop] < a[prop]) ? -1 : 0);
            }
        );
        this.setState({ employees: sortedData });
    }

    setupEmployeePage(empId) {
        sessionStorage.setItem('employeeId', empId);
    }

    async refreshEmployees() {
        fetch(variables.API_URL_Employee).then(response => response.json())
        .then(data => { this.setState({ employees: data, employeesWithoutFilter: data }); })
    }

    async refreshSkills() {
        fetch(variables.API_URL_Skill).then(response => response.json())
        .then(data => { this.setState({ skills: data }); });
    }
}