<template>
  <div class="container">
    <AdminSaleTitle/>
    <SaleItem
      v-for="sale in sales"
      v-bind:sale="sale"
      v-bind:key="sale.id">
    </SaleItem>
  </div>
</template>


<script lang="ts">
import { defineComponent } from 'vue'
import AdminSaleTitle from '@/components/sales/AdminSaleTitle.vue'
import SaleItem from './SaleItem.vue';

import SaleInterface from '@/Interfaces/SaleInterface'

export default defineComponent({
  name: "SaleList",
  components: {
    AdminSaleTitle,
    SaleItem
  },
  data() {
    return {
      sales: []
    }
  },
  mounted() {
    this.getSales();
  },
  methods: {
    getSales() {
      SaleInterface.getAll().then(json => {this.sales = json.data});
    }
  }
});
</script>


<style scoped>
.container {
  display: flex;
  flex-direction: column;
  margin: 8%;
  width: 90%;
  height: 90%;
  justify-content: top;
  align-items: center;
}
</style>