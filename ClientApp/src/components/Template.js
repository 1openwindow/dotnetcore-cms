import React, { Component } from 'react';
import { Button } from 'react-bootstrap';

export class Template extends Component {
	displayName = 'Tempalte';

	constructor(props){
		super(props);
		this.state = { templateData: [], loading: true};

		fetch('api/Template/ListTemplateData')
			.then(response => response.json())
			.then(data => {
				this.setState({ templateData: data, loading: false});
			});
	}

  static renderTemplateTable(templateData) {
    return (
      <table className='table'>
        <thead>
          <tr>
            <th>Id</th>
            <th>Url</th>
						<th>Tile Name</th>
            <th>Tile Image</th>
            <th>Tile Link</th>
						<th>Tile Description</th>
						<th>Create Time</th>
						<th>Update Time</th>
          </tr>
        </thead>
        <tbody>
					{templateData.map(templateData =>
            <tr key={templateData.templateId}>
              <td>{templateData.templateId}</td>
              <td>{templateData.url}</td>
              <td>{templateData.tileName}</td>
              <td>{templateData.tileImageUrl}</td>
							<td>{templateData.tileLink}</td>
							<td>{templateData.tileDescription}</td>
							<td>{templateData.createTime}</td>
							<td>{templateData.updateTime}</td>
            </tr>
          )}
        </tbody>
      </table>
    );
	}

	render() {
		let contents = this.state.loading
			? <p><em>Loading...</em></p>
			: Template.renderTemplateTable(this.state.templateData);

		return (
			<div>
				<h1>View Template</h1>
					<p>This component demonstrates Template data from server</p>
					{contents}
					<Button bsStyle="info" onClick={this.handSubmit}>Review</Button>
					{/* <form onSubmit={this.templateData}>
						<FormGroup role="form">
							<FormControl type="text" className="form-control"/>
							<Button className="btn btn-primary btn-large centerButton" type="submit">Send</Button>
						</FormGroup>
					</form> */}
			</div>
			
		)
	}
}