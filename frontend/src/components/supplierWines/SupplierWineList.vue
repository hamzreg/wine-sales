<template>
  <div class="containerSupplierWineList">
    <router-link style="text-decoration: none" to="/addSupplierWine">
        <Button class="add-button">Добавить вино</Button>
      </router-link>
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
import Button from '../button/Button.vue'

import SupplierInterface from '@/Interfaces/SupplierInterface'

export default defineComponent({
  name: "SupplierWineList",
  components: {
    SupplierWineItem,
    Button
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
.add-button {
  display: flex;
  flex-direction: column;
  position: absolute;
  left: 80%;
}
.innerContainer {
  display: flex;
  flex-direction: column;
  width: 94%;
  height: 100%;
  margin-top: 5%;
  margin-bottom: 2%;
  justify-content: top;
  align-items: center;
  background-color: var(--beige-color);
}
.containerSupplierWineList {
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