import React, { Component } from 'react';
import AppBar from '@material-ui/core/AppBar';
import Toolbar from '@material-ui/core/Toolbar';
import Typography from '@material-ui/core/Typography';
import Table from '@material-ui/core/Table';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TableHead from '@material-ui/core/TableHead';
import TableRow from '@material-ui/core/TableRow';
import {FormControl, InputLabel, MenuItem, Select} from '@material-ui/core';
import Paper from '@material-ui/core/Paper';
import { connect } from "react-redux"
import fetchModels,{fetchModel}  from './redux/action';
import Loading from './loading'
import './App.css';

class App extends Component {
  constructor(props, context) {
    super(props, context);

  }
  
  componentDidMount() {
    this.props.fetchModels();
  }

  render = () => {
    if(this.props.loading) return  <Loading/>
    var models = this.props.models;
    var selectModel = this.props.selectModel;
    var years = this.props.years;
    const handleChange = (event) => {
        this.props.fetchModel(event.target.value);
    }

    return (
      <div>
        <AppBar position="static">
          <Toolbar variant="dense">
            <Typography variant="h6" color="inherit">
              Vehicle List
            </Typography>
          </Toolbar>
        </AppBar>
        <Typography variant="h5" component="h2">
          Lotus
        </Typography>
        <FormControl style={{width: 300}}>
          <InputLabel id="model">Select Model</InputLabel>
            <Select
              labelId="model-select-label"
              id="model-select"
              value={selectModel}
              label="Model"
              onChange={handleChange}
            > 
              <MenuItem key={'all'} value={''}>{'All'}</MenuItem>
              {models.map(model => (
                <MenuItem key={model.name} value={model.name}>{model.name}</MenuItem>
              ))}
            </Select>
        </FormControl>
        <Paper>
          <Table aria-label="simple table">
            <TableHead>
              {
                selectModel === "" ?               
                <TableRow>
                  <TableCell>Name</TableCell>
                  <TableCell>Years Available</TableCell>
                </TableRow>
                :
                <TableRow>
                  <TableCell>Select Model</TableCell>
                  <TableCell>All Years</TableCell>
                </TableRow>
              }
            </TableHead>
            {
              selectModel === "" ?
              <TableBody>
              {models.map(model => (
                <TableRow key={model.name + model.yearsAvailable}>
                  <TableCell component="th" scope="row">
                    {model.name}
                  </TableCell>
                  <TableCell>{model.yearsAvailable}</TableCell>
                </TableRow>
              ))}
            </TableBody>
             :
             <TableBody>
               <TableRow>
                 <TableCell component="th" scope="row">
                   {selectModel}
                 </TableCell>
                 <TableCell>{years.join(', ')}</TableCell>
               </TableRow>
           </TableBody>
            }

          </Table>
        </Paper>
      </div>
    );
  };
}

export default connect(
  state => ({
    models: state.models,
    selectModel: state.selectModel,
    years: state.years,
    loading: state.loading,
  }),{
    fetchModels, fetchModel
  }
)(App)
