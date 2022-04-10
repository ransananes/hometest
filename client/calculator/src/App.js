import React, { useEffect, useState } from "react";
import "./App.css";
import {
  Typography,
  TextField,
  MenuItem,
  FormControl,
  Select,
  InputLabel,
  Button,
} from "@mui/material";
import { fetchOperations, postOperation } from "./api/operations";

function App() {
  const [firstNumber, setFirstNumber] = useState(0);
  const [currentOperation, setOperation] = useState("");
  const [secondNumber, setSecondNumber] = useState(0);
  const [result, setResult] = useState(0);
  const [availableOperations, setAvailableOperations] = useState([]);

  function handleChangeOperation(e) {
    setOperation(e.target.value);
  }
  function handleChangeFirstNumber(e) {
    setFirstNumber(e.target.value);
  }
  function handleChangeSecondNumber(e) {
    setSecondNumber(e.target.value);
  }
  useEffect(() => {
    // Update the available Operations via restapi
    fetchOperations().then((res) => {
      setAvailableOperations(res.data);
    });
  }, []);

  function requestResult() {
    // get the numbers via queryselector and add them into a list
    let allInputs = document.querySelectorAll(".number");
    let numbers = [];
    allInputs.forEach((input) => {
      numbers.push(input.value);
    });
    let allOperations = document.querySelectorAll("#operations-select");
    let operations = [];
    allOperations.forEach((operate) => {
      operations.push(operate.value);
    });
    var data = {
      numbers: numbers,
      operations: operations,
    };
    postOperation(data).then((res) => {
      let result = JSON.parse(res.data)
      setResult(result.value)
    })
  }
  return (
    <div className="App">
      <Typography variant="h1" component="h2">
        Calculator
      </Typography>
      <input
        id="outlined-basic"
        className="number"
        type="number"
        label="First Number"
        value={firstNumber}
        variant="outlined"
        onChange={handleChangeFirstNumber}
      />
      <div className="little_form">
      <FormControl fullWidth={true}>
        <InputLabel id="simple-select-label">Operation</InputLabel>
        <select name="select" id="operations-select">
          {availableOperations.map((operation, i) => (
            <option key={i} value={operation}>
              {operation}
            </option>
          ))}
        </select>
      </FormControl>
      </div>
      <input
        id="outlined-basic"
        type="number"
        className="number"
        label="Second Number"
        value={secondNumber}
        variant="outlined"
        onChange={handleChangeSecondNumber}
      />
      <Button variant="text" onClick={() => requestResult()}>
        Calculate
      </Button>
      <TextField
        id="outlined-basic"
        variant="outlined"
        value={result}
        disabled={true}
      />
    </div>
  );
}

export default App;
