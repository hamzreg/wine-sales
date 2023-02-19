<template>
  <Background>
    <body class="container">
      <body class="add-wine-container">
        <form class="form-column" @submit.prevent="onSubmit">
            <Text fontSize="var(--little-text)" fontColor>
              Добавление вина
            </Text>
            <InputLine @kind="setKind" name="kind" fontSize="var(--tiny-text)" placeholderText="Сорт"/>
            <InputLine @color="setColor" name="color" fontSize="var(--tiny-text)" placeholderText="Цвет"/>
            <InputLine @sugar="setSugar" name="sugar" fontSize="var(--tiny-text)" placeholderText="Сахар"/>
            <InputLine @alcohol="setAlcohol" name="alcohol" fontSize="var(--tiny-text)" placeholderText="Алкоголь (%)"/>
            <InputLine @volume="setVolume" name="volume" fontSize="var(--tiny-text)" placeholderText="Объем (л)"/>
            <InputLine @price="setPrice" name="price" fontSize="var(--tiny-text)" placeholderText="Цена (₽)"/>
            <InputLine @percent="setPercent" name="percent" fontSize="var(--tiny-text)" placeholderText="Процент"/>
            <FormButton>
              Добавить
            </FormButton>
            <div class="form-row">
              <Text fontSize="var(--tiny-text)">
                <router-link style="color: var(--wine-color)" to="/supplierWines">Отмена</router-link>
              </Text>
            </div>
        </form>
      </body>
    </body>
  </Background>
</template>


<script lang="ts">
import { defineComponent } from 'vue'
import InputLine from '@/components/InputLine.vue'
import Text from "@/components/Text.vue"
import FormButton from "@/components/button/FormButton.vue"
import Background from "@/components/background/Background.vue"

import { Wine } from '@/Interfaces/WineInterface'
import WineInterface from '@/Interfaces/WineInterface'
import { SupplierWine } from '@/Interfaces/SupplierWineInterface'
import SupplierWineInterface from '@/Interfaces/SupplierWineInterface'
import auth from "@/authentificationService";
import router from "@/router";

export default defineComponent({
  name: "AddSupplierWineForm",
  components: {
    InputLine,
    FormButton,
    Text,
    Background,
  },
  data () {
    return {
      kind: '',
      color: '',
      sugar: '',
      alcohol: 0,
      minAlcohol: 7.5,
      maxAlcohol: 22,
      volume: 0,
      minVolume: 0.1875,
      maxVolume: 30,
      price: 0,
      minPrice: 118,
      percent: 0,
      minPercent: 43
    }
  },
  methods: {
    async onSubmit() {
      if (this.kind == '' || this.color == '' || this.sugar == '' || this.alcohol == 0 || this.volume == 0 || this.price == 0 || this.percent == 0) {
        this.$notify({
          title: "Ошибка",
          text: "Все поля должны быть заполнены.",
        });
        return;
      }

      if (this.alcohol < this.minAlcohol || this.alcohol > this.maxAlcohol) {
        this.$notify({
          title: "Ошибка",
          text: "Содержание алкоголя должно быть в пределах [7.5;22] %.",
        });
        return;
      }

      if (this.volume < this.minVolume || this.volume > this.maxVolume) {
        this.$notify({
          title: "Ошибка",
          text: "Объем должен быть в пределах [0.1875;30] л.",
        });
        return;
      }

      if (this.price < this.minPrice) {
        this.$notify({
          title: "Ошибка",
          text: "Цена должна быть больше или равна 118 ₽.",
        });
        return;
      }

      if (this.percent < this.minPercent) {
        this.$notify({
          title: "Ошибка",
          text: "Процент должен быть больше или равен 43 %.",
        });
        return;
      }

      const wine: Wine = {
        id: 0,
        kind: this.kind,
        color: this.color,
        sugar: this.sugar,
        volume: this.volume,
        alcohol: this.alcohol,
        number: 1,
      }

      console.log(wine);

      const wineResult = await WineInterface.post(wine);
      console.log(wineResult.status);

      if (wineResult.status == 201) {
        console.log(wineResult.data["ID"]);
      }

      // const supplierWine: SupplierWine = {
      //   id: 1,
      //   supplierId: auth.getCurrentUser().roleId,
      //   wineId: 1,
      //   price: this.price,
      //   percent: this.percent,
      // }

      // console.log(supplierWine)

    },
    setKind(kind : string) {
      this.kind = kind;
    },
    setColor(color : string) {
      this.color = color;
    },
    setSugar(sugar : string) {
      this.sugar = sugar;
    },
    setAlcohol(alcohol : number) {
      this.alcohol = alcohol;
    },
    setVolume(volume : number) {
      this.volume = volume;
    },
    setPrice(price : number) {
      this.price = price;
    },
    setPercent(percent : number) {
      this.percent = percent;
    },
  }
})
</script>

<style scoped>
.container {
  display: flex;
  margin: 0;
  width: 100%;
  height: 100%;
  justify-content: center;
  align-items: center;
}
.add-wine-container {
  background: var(--green-color);
  box-shadow: 0px 0px 20px ;
  border-radius: 18px;
  padding-left: 2%;
  padding-right: 2%;
  padding-top: 1%;
  padding-bottom: 1%; 
  color: var(--beige-color);
  width: 30%;
  
}
.form-column {
  display: flex;
  flex-direction: column;
  text-align: center;
  gap: 10px;
}

.form-row {
  display: flex;
  flex-direction: column;
  gap: 10px;
  justify-content: center;
}
</style>