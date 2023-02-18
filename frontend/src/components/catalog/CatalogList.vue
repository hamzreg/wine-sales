<template>
  <div class="containerCatalogList">
    <!-- <div class="innerContainer"> -->
      <CatalogItem
        v-for="supplierWine in supplierWines"
        v-bind:supplierWine="supplierWine"
        v-bind:key="supplierWine.id">
      </CatalogItem>
    <!-- </div> -->
  </div>
</template>


<script lang="ts">
import { defineComponent } from 'vue'
import AdminSaleTitle from '@/components/sales/AdminSaleTitle.vue'
import CatalogItem from './CatalogItem.vue';

import WineInterface from '@/Interfaces/WineInterface'
import SupplierWineInterface from '@/Interfaces/SupplierWineInterface'

export default defineComponent({
  name: "CatalogList",
  components: {
    CatalogItem
  },
  data() {
    return {
      supplierWines: []
    }
  },
  mounted() {
    this.getSupplierWines();
  },
  methods: {
    getSupplierWines() {
      SupplierWineInterface.getAll().then(json => {this.supplierWines = json.data});
    }
  }
});
</script>


<style scoped>
/* .innerContainer {
  display: flex;
  flex-direction: column;
  width: 94%;
  height: 100%;
  justify-content: top;
  align-items: center;
  background-color: var(--beige-color);
} */
.containerCatalogList {
  display: grid;
  grid-template-columns: 1fr 1fr 1fr;
  flex-direction: column;
  margin-top: 8%;
  width: 100%;
  height: 90%;
  justify-content: top;
  align-items: center;
  background-color: var(--beige-color);
}
</style>