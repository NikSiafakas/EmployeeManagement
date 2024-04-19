import logo from './logo.svg';
import './App.css';
import { Component } from 'react'; 

let API_URL_Skill = "http://localhost:5273/api/Skill";
let API_URL_Employee = "http://localhost:5273/api/Employee";

class App extends Component {

  constructor(props) {
    super(props);
    this.state = { skills: [] }
  }

  componentDidMount() {
    this.refreshSkills();
  }

  render() {
    const{skills} = this.state;
    return (
      <div className="App">
        <h2>Employee Management</h2>

        {skills.map(skill =>
        <p>
          <b>* {skill.Name}</b>
        </p>
        )}

      </div>
    );
  }

  async refreshSkills() {
    fetch(API_URL_Skill).then(response => response.json())
    .then(data => {
      this.setState({ skills: data });
    })
  }
}

export default App;
