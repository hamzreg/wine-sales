<template>
<div class="outoutContainer">
  <form class="outContainer" @submit.prevent="getSupplierWines">
    <SelectLine @kind="setKind" name="kind" fontSize="var(--tiny-text)" placeholderText="Введите сорт"/>
    <SelectLine @wineColor="setColor" name="wineColor" fontSize="var(--tiny-text)" placeholderText="Введите цвет"/>
    <Button class="search-button">Поиск</Button>
  </form> 
  <div class="containerCatalogList">
      <CatalogItem
        v-for="supplierWine in supplierWines"
        v-bind:supplierWine="supplierWine"
        v-bind:key="supplierWine.id">
      </CatalogItem>
  </div>
</div>
</template>


<script lang="ts">
import { defineComponent } from 'vue'
import CatalogItem from './CatalogItem.vue';
import Button from '@/components/button/Button.vue'

import WineInterface from '@/Interfaces/WineInterface'
import SelectLine from '@/components/SelectLine.vue'
import SupplierWineInterface from '@/Interfaces/SupplierWineInterface'

export default defineComponent({
  name: "CatalogList",
  components: {
    CatalogItem,
    SelectLine,
    Button
  },
  data() {
    return {
      supplierWines: [],
      kindStr: '',
      colorStr: '',
    }
  },
  props: [
    "kind",
    "wineColor"
],
  mounted() {
    this.getSupplierWines();
  },
  methods: {
    async getSupplierWines() {
      console.log(this.kindStr, this.colorStr)
      if (this.kindStr != ""){
        const res = await SupplierWineInterface.getByKind(this.kindStr).then(json => {this.supplierWines = json.data});
      }
      else if (this.colorStr != ""){
        const res = await SupplierWineInterface.getByColor(this.colorStr).then(json => {this.supplierWines = json.data});
      }
      else {
        const res = await SupplierWineInterface.getAll().then(json => {this.supplierWines = json.data});
      }
    },

    setKind(kind : string) {
      this.kindStr = kind;
    },

    setColor(wineColor : string) {
      this.colorStr = wineColor;
    }
  }
});
</script>


<style scoped>
.search-button {
  width: 20%;
}
.outoutContainer {
  display: flex;
  flex-direction: column;
  margin: 0;
  width: 100%;
  height: 100%;
  justify-content: top;
  align-items: center;
  padding-top: 0%;
  gap: 20px;
}
.outContainer {
  display: grid;
  grid-template-columns: 1fr 1fr 1fr;
  gap: 25px;
  width: 80%;
  height: 15%;
  align-items: center;
  position: absolute;
  justify-content: center;
  text-align: center;
  margin: 6%;
}
.containerCatalogList {
  display: grid;
  grid-template-columns: 1fr 1fr 1fr;
  flex-direction: column;
  margin-top: 15%;
  width: 100%;
  height: 90%;
  justify-content: top;
  align-items: center;
  background-color: var(--beige-color);
}
</style>