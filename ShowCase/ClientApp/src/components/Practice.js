import React, { Component } from 'react';

export class Practice extends Component {
    static displayName = Practice.name;

    constructor(props) {
        super(props);
        this.state = { examples: [], loading: true };
    }

    componentDidMount() {
        this.populateExamplesData();
    }

    static renderExamplesTable(examples) {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Name</th>
                        <th>Worst Practice</th>
                        <th>Best Practice</th>
                        <th>Description</th>
                    </tr>
                </thead>
                <tbody>
                    {examples.map(example =>
                        <tr key={example.id}>
                            <td dangerouslySetInnerHTML={{ __html: example.name }} />
                            <td dangerouslySetInnerHTML={{ __html: example.worstPractice }} />
                            <td dangerouslySetInnerHTML={{ __html: example.bestPractice }} />
                            <td dangerouslySetInnerHTML={{ __html: example.description }} />
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : Practice.renderExamplesTable(this.state.examples);

        return (
            <div>
                <h1 id="tabelLabel" >REST does and donts</h1>
                {contents}
            </div>
        );
    }

    async populateExamplesData() {
        const response = await fetch('api/examples');
        const data = await response.json();
        this.setState({ examples: data, loading: false });
    }
}
