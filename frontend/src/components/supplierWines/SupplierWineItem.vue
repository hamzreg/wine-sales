<template>
  <div class="supplierWine-item">
    <img src="@/assets/img/wineBottle.svg" height="200" class="item"/>
		<Text class="item" font-size="var(--little-text)" color="var(--green-color)">
			{{ wine.kind }} {{ wine.color }} {{ wine.sugar }} {{ wine.volume }} л
		</Text>
		<Text class="item" font-size="var(--little-text)" color="var(--green-color)">
			{{ supplierWine.price }} ₽
		</Text>
    <Button v-on:click="deleteSupplierWine" class="item">Удалить</Button>
  </div>
</template>
  
  
<script lang="ts">
import { defineComponent } from 'vue'
import Text from '@/components/Text.vue'
import Button from '../button/Button.vue'

import SupplierWineInterface from '@/Interfaces/SupplierWineInterface'
import WineInterface from '@/Interfaces/WineInterface'
import router from '@/router'
    
export default defineComponent({
  name: "SupplierWineItem",
  components: {
    Text,
    Button
  },
  props: {
    supplierWine: {
      type: Object,
      required: true
    }
  },
  data() {
    return {
      wine: {
        id: 0,
        kind: '',
        color: '',
        sugar: '',
        volume: 0
      }
    }
  },
  mounted() {
    WineInterface.getById(this.supplierWine["wineID"]).then(json => {this.wine = json.data});
  },
  methods: {
    deleteSupplierWine: function() {
      WineInterface.delete(this.wine.id);
      SupplierWineInterface.delete(this.supplierWine.id);
      router.push("/supplierWines");
    }
  }
})
</script>
  
  
<style scoped>
.supplierWine-item {
  display: grid;
  grid-template-columns: 0.5fr 2fr 0.5fr;
  column-gap: 50px;
  width: 90%;
  padding-top: 3%;
}
.item:nth-child(1) {
  grid-column: 1;
  grid-row: span 3;
}
.item:nth-child(2) {
  grid-column: 2;
  grid-row: span 1;
}
.item:nth-child(3) {
  grid-column: 3;
  grid-row: span 1;
  justify-self: center;
}
.item:nth-child(4) {
  grid-column: 3;
  grid-row: 3;
  height: 100%;
  width: 50%;
  justify-self: center;
}
</style>