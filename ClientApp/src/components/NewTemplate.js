import React, { Component } from 'react';
import { Button, Form, HelpBlock, FormGroup, ControlLabel, FormControl } from 'react-bootstrap';


export class NewTemplate extends Component {
	displayName = 'New Tempalte';

	constructor(props, context) {
		super(props, context);

		this.handleChange = this.handleChange.bind(this);

		this.state = {
			value: '',
			tileName: '',
			tileLink: '',
			tileUrl: '',
		};
	}

	getValidationState() {
		const length = this.state.value.length;
		if (length > 10) return 'success';
		else if (length > 5) return 'warning';
		else if (length > 0) return 'error';
		return null;
	}

	handleChange(e) {
		this.setState({ value: e.target.value });
	}

	handleTemplateCreate() {

		// if (blogStatus == constants.BLOG_STATUS_PUBLISH) {
		// 	this.setState({ isPublishingBlog: true });
		// }
		// else {
		// 	this.setState({ isSavingBlog: true });
		// }

		let paramData = {
			tileLink: this.state.tileLink,
			tileName: this.state.tileName,
			tileUrl: this.state.tileUrl,
		};

		fetch('api/Template/CreateTemplate', {
			method: 'post',
			headers: {
				'Accept': 'application/json, text/plain, */*',
				'Content-Type': 'application/json'
			},
			body: JSON.stringify(paramData),
		})
			.then(function (response) {
				return response.json();
			})
			.then(function (result) {
				alert(result);
			})
			.catch(function (error) {
				console.log('Request failed', error);
			});
	}

	render() {
		function FieldGroup({ id, label, help, ...props }) {
			return (
				<FormGroup controlId={id}>
					<ControlLabel>{label}</ControlLabel>
					<FormControl {...props} />
					{help && <HelpBlock>{help}</HelpBlock>}
				</FormGroup>
			);
		};

		return (
			<Form>
				<FormGroup
					controlId="formBasicText"
					validationState={this.getValidationState()}
				>
					<ControlLabel>Working example with validation</ControlLabel>
					<FormControl
						type="text"
						value={this.state.value}
						placeholder="Enter text"
						onChange={this.handleChange}
					/>
					<FormControl.Feedback />
					<HelpBlock>Validation is based on string length.</HelpBlock>
				</FormGroup>
				<FieldGroup
					id="formControlsText"
					type="text"
					label="Tile Name"
					placeholder="Enter Name"
					value={this.state.tileName}
				/>
				<FieldGroup
					id="formControlsEmail"
					type="text"
					label="Tile Link"
					placeholder="Enter Link"
					value={this.state.tileLink}
				/>
				<FieldGroup
					id="formControlsUrl"
					type="text"
					label="Tile Url"
					placeholder="Enter URL"
					value={this.state.tileUrl}
				/>
				<FormGroup controlId="formControlsTextarea">
					<ControlLabel>Tile Description</ControlLabel>
					<FormControl componentClass="textarea" placeholder="textarea" />
				</FormGroup>
				<Button type="submit" onClick={this.handleTemplateCreate} >Submit</Button>
			</Form>
		);
	}
}