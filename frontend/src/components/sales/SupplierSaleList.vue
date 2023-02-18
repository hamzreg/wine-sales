<template>
  <div class="containerSaleList">
    <div class="innerContainer">
      <SupplierSaleTitle/>
      <SupplierSaleItem
        v-for="sale in sales"
        v-bind:sale="sale"
        v-bind:key="sale.id">
      </SupplierSaleItem>
    </div>
  </div>
</template>


<script lang="ts">
import { defineComponent } from 'vue'
import SupplierSaleTitle from './SupplierSaleTitle.vue'
import SupplierSaleItem from './SupplierSaleItem.vue'
import authentificationService from '@/authentificationService'

import SupplierInterface from '@/Interfaces/SupplierInterface'

export default defineComponent({
  name: "SupplierSaleList",
  components: {
    SupplierSaleTitle,
    SupplierSaleItem
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
      SupplierInterface.getSales(authentificationService.getCurrentUser().id).then(json => {this.sales = json.data});
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