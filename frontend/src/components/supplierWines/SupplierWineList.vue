<template>
  <div class="containerSupplierWineList">
    <div class="innerContainer">
      <SupplierWineItem
        v-for="supplierWine in supplierWines"
        v-bind:supplierWine="supplierWine"
        v-bind:key="supplierWine.id">
      </SupplierWineItem>
    </div>
  </div>
</template>


<script lang="ts">
import { defineComponent } from 'vue'
import SupplierWineItem from './SupplierWineItem.vue'
import authentificationService from '@/authentificationService'

import SupplierInterface from '@/Interfaces/SupplierInterface'

export default defineComponent({
  name: "SupplierWineList",
  components: {
    SupplierWineItem
  },
  data() {
    return {
      supplierWines: []
    }
  },
  mounted() {
    SupplierInterface.getSupplierWines(authentificationService.getCurrentUser().roleId).then(json => {this.supplierWines = json.data});
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
.containerSupplierWineList {
  display: flex;
  flex-direction: column;
  margin-top: 6%;
  width: 100%;
  height: 90%;
  justify-content: top;
  align-items: center;
  background-color: var(--beige-color);
}
</style>