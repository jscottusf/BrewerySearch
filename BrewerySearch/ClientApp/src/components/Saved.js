import React, { Component } from 'react';
import API from '../utils/API';
import { CardDiv, CardBody, CardTitle, CardSubtitle, CardText } from './BootstrapCard';
import GridContainer from './GridContainer';
import { Link } from 'react-router-dom';
import Rating from './Rating';

class Brewery extends Component {
    constructor(props) {
        super(props);
        this.route = window.location.pathname.split('/');
        this.breweryId = this.route[2];
        this.state = {
            message: "...loading",
            breweries: []
        }
    }

    componentDidMount = () => {
        this.loadSavedBreweries();

    }

    loadSavedBreweries = () => {
        API.getBreweries().then(res => {
            this.setState({
                breweries: res.data,
                //will render if results are 0
                message: 'you have no saved breweries, yet'
            })
        }).catch(err => console.log(err));
    }

    handleDeleteBreweryClick = (event, id) => {
        event.preventDefault();
        API.deleteBrewery(id).then(res => {
            this.componentDidMount();
        }).catch(err => console.log(err));
    }

    render() {
        return (
            <div className="container mt-3" id="main-container">
                {this.state.breweries.length ? (
                    <GridContainer style={{ gridTemplateColumns: '1fr 1fr' }}>
                    {this.state.breweries.map(brew => (
                            <CardDiv>
                                <CardBody>
                                <div id="save">
                                    <i id="x" className="fas fa-times" onClick={(event, id) => this.handleDeleteBreweryClick(event, brew.id)} ></i>
                                    </div>
                                    <GridContainer style={{ gridTemplateColumns: '20% 1fr' }}>
                                        <div id="breweryImgDiv">
                                            <img id="breweryImg" alt={brew.name} src={brew.logo} />
                                        </div>
                                        <div>
                                        <CardTitle>{brew.breweryName}</CardTitle>
                                            <CardSubtitle>{brew.address}</CardSubtitle>
                                            <CardSubtitle>{brew.city}, {brew.state}</CardSubtitle>
                                            <Link to={brew.url}> Beer List </Link>
                                        </div>
                                </GridContainer>
                                <Rating rating={brew.rating}
                                    id={brew.id}
                                    Name={brew.breweryName}
                                    Logo={brew.logo}
                                    Address={brew.address}
                                    City={brew.city}
                                    State={brew.state}
                                    Url={brew.url}
                                    loadSavedBreweries={this.loadSavedBreweries} />
                            </CardBody>
                            </CardDiv>
                    ))}
                    </GridContainer>
                ) : <h4> { this.state.message }</h4>}
            </div>
        )
    }
}

export default Brewery;