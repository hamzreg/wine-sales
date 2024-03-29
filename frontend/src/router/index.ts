import { createRouter, createWebHistory, RouteRecordRaw } from 'vue-router'
import HomeView from '../views/HomeView.vue'
import TestView from '../views/TestView.vue'
import TestViewGadzhi from '../views/TestViewGadzhi.vue'
import Authorization from '../views/AuthorizationView.vue'
import Registration from '../views/RegistrationView.vue'
import AdminSalesView from '@/views/AdminSalesView.vue'
import SupplierSalesView from '@/views/SupplierSalesView.vue'
import SupplierWinesView from '@/views/SupplierWinesView.vue'
import AddSupplierWineForm from '@/components/supplierWines/AddSupplierWineForm.vue'
import CatalogView from '@/views/CatalogView.vue'
import AboutWinesView from '@/views/AboutWinesView.vue'

const routes: Array<RouteRecordRaw> = [
  {
    path: '/',
    name: 'home',
    component: HomeView
  },

  {
    path: '/test',
    name: 'test',
    component: TestView
  },

  {
    path: '/testG',
    name: 'testG',
    component: TestViewGadzhi
  },

  {
    path: '/auth',
    name: 'Authorization',
    component: Authorization
  },

  {
    path: '/registration',
    name: 'Registration',
    component: Registration
  },

  {
    path: '/sales',
    name: 'Sales',
    component: AdminSalesView
  },

  {
    path: '/supplierSales',
    name: 'SupplierSales',
    component: SupplierSalesView
  },

  {
    path: '/supplierWines',
    name: 'SupplierWines',
    component: SupplierWinesView
  },

  {
    path: '/addSupplierWine',
    name: 'AddSupplierWine',
    component: AddSupplierWineForm
  },

  // {
  //   path: '/catalog',
  //   name: 'Catalog',
  //   component: CatalogView
  // },

  {
    path: "/catalog:color?:kind?",
    name: "catalog",
    component: CatalogView,
    props: true,
  },

  {
    path: '/aboutWines',
    name: 'AboutWines',
    component: AboutWinesView
  },
]

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
})

export default router
