<template>
  <div class="container">
    <SaleItem
      v-for="sale in sales"
      v-bind:sale="sale"
      v-bind:key="sale.id">
    </SaleItem>
  </div>
</template>


<script lang="ts">
import { defineComponent } from 'vue'
import SaleItem from './SaleItem.vue';

import SaleInterface from '@/Interfaces/SaleInterface'

export default defineComponent({
  name: "SaleList",
  components: {
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
  flex-wrap: wrap;
  align-content: space-between;
  min-height: 550px;
  width: 100%
}
</style>