import React, { Component } from 'react';
import { variables } from './Variables';

export class Employee extends Component {

    constructor(props) {
        super(props);
        this.state = {
            skills: [],
            employeeId: '',
            employeeName: '',
            employeeSurname: '',
            employeeEmail: '',
            employeePhone: '',
            employeeHired: new Date().toISOString().split('T')[0],
            employeeSkillset: [],
            employeeSkillsetUpdated: '',
            employeeSkillset_InfoList: []
        }
    }

    render() {
        const { skills, employeeId, employeeName, employeeSurname, employeeEmail, employeePhone, employeeHired, employeeSkillsetUpdated, employeeSkillset_InfoList } = this.state;

        const employeeExists = employeeId > 0;
        
        return (
            <div>
                { !employeeExists ? <button type='button' className='btn btn-primary m-2 float-end' onClick={() => this.createEmployee()}>Create</button> : null }
                { employeeExists ? <button type='button' className='btn btn-primary m-2 float-end' onClick={() => this.deleteEmployee()}>Delete</button> : null }
                { employeeExists ? <button type='button' className='btn btn-primary m-2 float-end' onClick={() => this.updateEmployee()}>Update</button> : null }
                    
                <form className="row g">
                    <div className='row g-2'>
                        <div className='col'>
                            <label>Name</label>
                            <input type='text' className='form-control' value={employeeName} onChange={this.changeName}/>
                        </div>
                        <div className='col'>
                            <label>Surname</label>
                            <input type='text' className='form-control' value={employeeSurname} onChange={this.changeSurname}/>
                        </div>
                    </div>
                    <div className='row g-2'>
                        <div className='col'>
                            <label>Email</label>
                            <input type='email' className='form-control' value={employeeEmail} onChange={this.changeEmail}/>
                        </div>
                        <div className='col'>
                            <label>Phone</label>
                            <input type='phone' className='form-control' value={employeePhone} onChange={this.changePhone}/>
                        </div>
                    </div>
                    <div className='row g-2'>
                        <div className='col'>
                            <label>Hired</label>
                            <input type='date' className='form-control' value={new Date(employeeHired).toISOString().split('T')[0]} onChange={this.changeHired}/>
                        </div>
                        {employeeExists ?
                        <div className='col'>
                            <label>Skillset Updated</label>
                            <input type='date' className='form-control' value={new Date(employeeSkillsetUpdated).toISOString().split('T')[0]} readOnly/>
                        </div> : <div className='col'></div>}
                    </div>
                    <div className='row g-1'>
                        <table className='table table-striped'>
                            <thead>
                                <tr>
                                    <th>Skill Name</th>
                                    <th>Description</th>
                                    <th><select className="form-select" id="addSkillSelect">
                                    <option defaultValue>Add Skill</option>
                                    {skills.map(a => (
                                    <option key={a.Id} value={a.Id}>{a.Name}</option>))}
                                    </select></th>
                                    <th><button type="button" className='btn btn-light mr-1 float-end' onClick={() => this.addSkill()}>
                                    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" className="bi bi-plus-square" viewBox="0 0 16 16">
                                    <path d="M14 1a1 1 0 0 1 1 1v12a1 1 0 0 1-1 1H2a1 1 0 0 1-1-1V2a1 1 0 0 1 1-1zM2 0a2 2 0 0 0-2 2v12a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V2a2 2 0 0 0-2-2z"/>
                                    <path d="M8 4a.5.5 0 0 1 .5.5v3h3a.5.5 0 0 1 0 1h-3v3a.5.5 0 0 1-1 0v-3h-3a.5.5 0 0 1 0-1h3v-3A.5.5 0 0 1 8 4"/>
                                    </svg></button></th>
                                </tr>
                            </thead>
                            <tbody>
                                {employeeSkillset_InfoList.map(a =>
                                <tr key={a.Id}>
                                    <td>{a.Name}</td>
                                    <td>{a.Description}</td>
                                    <td></td>
                                    <td><button type="button" className='btn btn-light mr-1 float-end' onClick={() => this.removeSkill(a)}>
                                    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" className="bi bi-dash-square" viewBox="0 0 16 16">
                                    <path d="M14 1a1 1 0 0 1 1 1v12a1 1 0 0 1-1 1H2a1 1 0 0 1-1-1V2a1 1 0 0 1 1-1zM2 0a2 2 0 0 0-2 2v12a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V2a2 2 0 0 0-2-2z"/>
                                    <path d="M4 8a.5.5 0 0 1 .5-.5h7a.5.5 0 0 1 0 1h-7A.5.5 0 0 1 4 8"/>
                                    </svg></button></td></tr>)}
                            </tbody>
                        </table>
                    </div>
                </form>
            </div>
        )
    }
    
    componentDidMount() {
        let empId = sessionStorage.getItem('employeeId');
        if (!empId || empId=='') empId = -2;
        this.getEmployee(empId);
        this.refreshSkills();
    }
    
    changeName = (e) => { this.setState({ employeeName: e.target.value }); }
    changeSurname = (e) => { this.setState({ employeeSurname: e.target.value }); }
    changeEmail = (e) => { this.setState({ employeeEmail: e.target.value }); }
    changePhone = (e) => { this.setState({ employeePhone: e.target.value }); }
    changeHired = (e) => { this.setState({ employeeHired: e.target.value }); }

    addSkill() {
        let skillSelected = document.getElementById("addSkillSelect").value;
        let list = this.state.employeeSkillset_InfoList;
        if (list.find(a => a.Id == skillSelected)) return;

        let skill = this.state.skills.find(a => a.Id == skillSelected);
        list.push(skill);
        this.setState({ employeeSkillset_InfoList: list });
    }
    
    removeSkill(skl) {
        let list = this.state.employeeSkillset_InfoList;
        let skillIndex = list.findIndex((obj) => obj.Id === skl.Id);
        list.splice(skillIndex, 1);
        this.setState({ employeeSkillset_InfoList: list });
    }

    setEmployeeSkillsetInfoList() {
        let skillList = this.state.skills;
        let employeeSkillList = this.state.employeeSkillset;
        var employeeSkillsInfoList = skillList.filter(a => employeeSkillList.includes(a.Id));
        this.setState({employeeSkillset_InfoList: employeeSkillsInfoList});
    }

    async refreshSkills() {
        fetch(variables.API_URL_Skill).then(response => response.json())
        .then(data => { this.setState({ skills: data }, function() {this.setEmployeeSkillsetInfoList()}); })
    }

    async getEmployee(empId) {
        if (empId <= 0) return;
        fetch(variables.API_URL_Employee + '/' + empId).then(response => response.json())
        .then(data => {
            this.setState({
                employeeId: data.Id,
                employeeName: data.Name,
                employeeSurname: data.Surname,
                employeeEmail: data.Email,
                employeePhone: data.Phone,
                employeeHired: data.Hired,
                employeeSkillset: data.SkillsetList,
                employeeSkillsetUpdated: data.SkillsetUpdated
            }, function() {this.setEmployeeSkillsetInfoList()});
        })
    }

    async createEmployee() {
        fetch(variables.API_URL_Employee, {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                Name: this.state.employeeName,
                Surname: this.state.employeeSurname,
                Email: this.state.employeeEmail,
                Phone: this.state.employeePhone,
                Hired: this.state.employeeHired,
                SkillsetUpdated: new Date(),
                Skillset: this.state.employeeSkillset_InfoList.map(a => a.Id).toString()
            })
        }).then((result) => {
            if (result.ok) {
                sessionStorage.setItem('employeeId', '');
                alert('Created');
                window.location.replace('/Employees');
            } else alert('Unsuccessful');
        }, (error) => { alert(error); })
    }

    async updateEmployee() {
        fetch(variables.API_URL_Employee, {
            method: 'PUT',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                Id: this.state.employeeId,
                Name: this.state.employeeName,
                Surname: this.state.employeeSurname,
                Email: this.state.employeeEmail,
                Phone: this.state.employeePhone,
                Hired: this.state.employeeHired,
                SkillsetUpdated: this.state.employeeSkillsetUpdated,
                Skillset: this.state.employeeSkillset_InfoList.map(a => a.Id).toString()
            })
        }).then((result) => {
            if (result.ok) {
                sessionStorage.setItem('employeeId', '');
                alert('Updated');
                window.location.replace('/Employees');
            } else alert('Unsuccessful');
        }, (error) => { alert(error); })
    }

    async deleteEmployee() {
        if (window.confirm("Are you sure?") == false) return;
        fetch(variables.API_URL_Employee + '/' + this.state.employeeId, {
            method: 'DELETE',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            }
        }).then((result) => {
            sessionStorage.setItem('employeeId', '');
            alert(result.ok ? 'Deleted' : 'Unsuccessful');
            window.location.replace('/Employees');
        }, (error) => { alert(error); })
    }
}