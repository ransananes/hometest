import axios from 'axios';

const url = "https://localhost:44389/api/operations";

export const fetchOperations = () => axios.get(url);
export const postOperation = (data) => axios.post(url, data);

