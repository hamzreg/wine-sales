<template>
  <div class="containerSaleList">
    <div class="innerContainer">
      <AdminSaleTitle/>
      <SaleItem
        v-for="sale in sales"
        v-bind:sale="sale"
        v-bind:key="sale.id">
      </SaleItem>
    </div>
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
.innerContainer {
  display: flex;
  flex-direction: column;
  width: 94%;
  height: 100%;
  justify-content: top;
  align-items: center;
  background-color: var(--beige-color);
}
.containerSaleList {
  display: flex;
  flex-direction: column;
  margin-top: 8%;
  width: 100%;
  height: 90%;
  justify-content: top;
  align-items: center;
  background-color: var(--beige-color);
}
</style>