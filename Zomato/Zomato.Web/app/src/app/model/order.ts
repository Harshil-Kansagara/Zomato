import { CartItem } from './cart-item';

export interface Order {
  orderId: number;
  userId: string;
  addressId: number;
  restaurantId: number;
  orderDate: string;
  items: CartItem[];
}
