import http from "./httpService";

const apiEndpoint = "http://localhost:5000/api/orders";

export async function getOrders() {
  try {
    const response = await http.get(apiEndpoint);
    return response.data;
  } catch (ex) {}
}

export async function createOrder(input) {
  const response = await http.post(apiEndpoint, { input });
  return response.data;
}

export default {
  getOrders,
  createOrder
};
