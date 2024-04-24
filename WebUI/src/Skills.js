import React, { Component } from 'react';
import { variables } from './Variables';

export class Skills extends Component {

    constructor(props) {
        super(props);
        this.state = {
            skills: [],
            skillId: "",
            skillName: "",
            skillDescription: "",
            modalTitle: ""
        }
    }
      
    render() {
        const { skills, skillId, skillName, skillDescription, modalTitle } = this.state;
        return (
            <div>
                <button type='button' className='btn btn-primary m-2 float-end'
                data-bs-toggle='modal' data-bs-target='#exampleModal' onClick={() => this.addSkillClick()}>Add Skill</button>

                <table className='table table-striped'>
                    <thead>
                        <tr>
                            <th>Name</th>
                            <th>Description</th>
                            <th>Created</th>
                        </tr>
                    </thead>
                    <tbody>
                        {skills.map(a =>
                        <tr key={a.Id}>
                            <td>{a.Name}</td>
                            <td>{a.Description}</td>
                            <td>{new Date(a.Created).toISOString().split('T')[0]}</td>
                            <td><button type="button" className='btn btn-light mr-1'
                            data-bs-toggle='modal' data-bs-target='#exampleModal' onClick={() => this.editSkillClick(a)}>
                            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" className="bi bi-pencil-square" viewBox="0 0 16 16">
                            <path d="M15.502 1.94a.5.5 0 0 1 0 .706L14.459 3.69l-2-2L13.502.646a.5.5 0 0 1 .707 0l1.293 1.293zm-1.75 2.456-2-2L4.939 9.21a.5.5 0 0 0-.121.196l-.805 2.414a.25.25 0 0 0 .316.316l2.414-.805a.5.5 0 0 0 .196-.12l6.813-6.814z"/>
                            <path fillRule="evenodd" d="M1 13.5A1.5 1.5 0 0 0 2.5 15h11a1.5 1.5 0 0 0 1.5-1.5v-6a.5.5 0 0 0-1 0v6a.5.5 0 0 1-.5.5h-11a.5.5 0 0 1-.5-.5v-11a.5.5 0 0 1 .5-.5H9a.5.5 0 0 0 0-1H2.5A1.5 1.5 0 0 0 1 2.5z"/>
                            </svg></button>
                            <button type="button" className='btn btn-light mr-1' onClick={() => this.deleteSkill(a)}>
                            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" className="bi bi-trash" viewBox="0 0 16 16">
                            <path d="M5.5 5.5A.5.5 0 0 1 6 6v6a.5.5 0 0 1-1 0V6a.5.5 0 0 1 .5-.5m2.5 0a.5.5 0 0 1 .5.5v6a.5.5 0 0 1-1 0V6a.5.5 0 0 1 .5-.5m3 .5a.5.5 0 0 0-1 0v6a.5.5 0 0 0 1 0z"/>
                            <path d="M14.5 3a1 1 0 0 1-1 1H13v9a2 2 0 0 1-2 2H5a2 2 0 0 1-2-2V4h-.5a1 1 0 0 1-1-1V2a1 1 0 0 1 1-1H6a1 1 0 0 1 1-1h2a1 1 0 0 1 1 1h3.5a1 1 0 0 1 1 1zM4.118 4 4 4.059V13a1 1 0 0 0 1 1h6a1 1 0 0 0 1-1V4.059L11.882 4zM2.5 3h11V2h-11z"/>
                            </svg></button></td></tr>)}
                    </tbody>
                </table>

                <div className='modal fade' id="exampleModal" tabIndex={"-1"} aria-hidden="true">
                    <div className='modal-dialog modal-lg modal-dialog-centered'>
                        <div className='modal-content'>
                            <div className='modal-header'>
                                <h5 className='modal-title'>{modalTitle}</h5>
                                <button type='button' className='btn-close' data-bs-dismiss="modal" aria-label='Close'></button>
                            </div>
                            <div className='modal-body'>
                                <div className='input-group mb-3'>
                                    <span className='input-group-text'>Name</span>
                                    <input type='text' className='form-control' value={skillName} onChange={this.changeSkillName}/>
                                </div>
                                <div className='input-group mb-3'>
                                    <span className='input-group-text'>Description</span>
                                    <input type='text' className='form-control' value={skillDescription} onChange={this.changeSkillDescription}/>
                                </div>

                                { skillId == 0 ? <button type='button' className='btn btn-primary float-end' onClick={() => this.createSkill()}>Create</button> :
                                    <button type='button' className='btn btn-primary float-end' onClick={() => this.updateSkill()}>Update</button> }
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        )
    }
    
    componentDidMount() {
        this.refreshSkills();
    }

    addSkillClick() {
        this.setState({
            skillId: 0,
            skillName: "",
            skillDescription: "",
            modalTitle: "Add Skill"
        });
    }

    editSkillClick(skl) {
        this.setState({
            skillId: skl.Id,
            skillName: skl.Name,
            skillDescription: skl.Description,
            modalTitle: "Edit Skill"
        });
    }

    changeSkillName = (e) => { this.setState({ skillName: e.target.value }); }
    changeSkillDescription = (e) => { this.setState({ skillDescription: e.target.value }); }

    async refreshSkills() {
        fetch(variables.API_URL_Skill).then(response => response.json())
        .then(data => { this.setState({ skills: data }); });
    }

    async createSkill() {
        fetch(variables.API_URL_Skill, {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ Name: this.state.skillName, Description: this.state.skillDescription })
        }).then((result) => { result.ok ? alert('Created') : alert('Unsuccessful'); window.location.reload(); }, (error) => { alert(error); })
    }

    async updateSkill() {
        fetch(variables.API_URL_Skill, {
            method: 'PUT',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ Id: this.state.skillId, Name: this.state.skillName, Description: this.state.skillDescription })
        }).then((result) => { result.ok ? alert('Updated') : alert('Unsuccessful'); window.location.reload(); }, (error) => { alert(error); })
    }

    async deleteSkill(skl) {
        if (window.confirm("Are you sure?") == false) return;
        fetch(variables.API_URL_Skill + '/' + skl.Id, {
            method: 'DELETE',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            }
        }).then((result) => { this.refreshSkills(); if (!result.ok) alert('Unsuccessful'); }, (error) => { alert(error); })
    }
}