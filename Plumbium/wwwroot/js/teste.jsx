class Timer extends React.Component {
    constructor(props) {
        super(props);
        this.state = { secondsElapsed: 0 };
        this.pipelines = [];
        
        axios.get('/api/pipelines')
            .then(function (response) {
                console.log(response.data); // ex.: { user: 'Your User'}
                console.log(response.status); // ex.: 200
                this.pipelines = response.data;
            }); 

    }

    tick() {
        this.setState((prevState) => ({
            secondsElapsed: prevState.secondsElapsed + 1
        }));
    }

    componentDidMount() {
        this.interval = setInterval(() => this.tick(), 1000);
    }

    componentWillUnmount() {
        clearInterval(this.interval);
    }

    render() {
        return (
            //<div>Seconds Elapsed: {this.state.secondsElapsed}</div>
            <div>Teste: {this.pipelines.length}</div>
        );
    }
}

ReactDOM.render(<Timer />, document.getElementById('mountNode'));