<template>
  <div class="combobox" style="display: flex; width: 446px; height: 45px">
    <input
      type="text"
      class="combobox__input"
      v-model="textInput"
      @input="inputOnChange"
      @keydown="selecItemUpDown"
      tabindex="2"
      readonly
    />
    <button
      class="button combobox__button"
      @click="btnSelectDataOnClick"
      @keydown="selecItemUpDown"
      tabindex="2"
    >
      <!-- <i class="fa-solid fa-chevron-down"></i> -->
      <img class="button__icon" srcset="" width="14" height="14" />
    </button>
    <div
      v-if="isShowListData"
      class="combobox__data"
      ref="combobox__data"
      v-clickoutside="hideListData"
    >
      <a
        class="combobox__item"
        v-for="(item, index) in dataFilter"
        :class="{
          'combobox__item--focus': index == indexItemFocus,
          'combobox__item--selected': index == indexItemSelected,
        }"
        :key="item[this.propValue]"
        :ref="'toFocus_' + index"
        :value="item[this.propValue]"
        @click="itemOnSelect(item, index)"
        @focus="saveItemFocus(index)"
        @keydown="selecItemUpDown(index)"
        @keyup="selecItemUpDown(index)"
        tabindex="1"
      >
        <div class="combobox__item-icon">
          <img
            v-show="index == indexItemSelected"
            alt=""
            srcset=""
            width="14"
            height="11"
          />
        </div>
        <span>{{ item[this.propText] }}</span>
      </a>
    </div>
  </div>
</template>
<script>
/**
 * Gán sự kiện nhấn click chuột ra ngoài để ẩn combobox data
 * HNSINH (31/07/2022)
 */
const clickoutside = {
  mounted(el, binding) {
    el.clickOutsideEvent = (event) => {
      // Nếu element hiện tại không phải là element đang click vào
      // Hoặc element đang click vào không phải là button trong combobox hiện tại thì ẩn đi.
      if (
        !(
          (
            el === event.target || // click phạm vi của combobox__data
            el.contains(event.target) || //click vào element con của combobox__data
            el.previousElementSibling.contains(event.target)
          ) //click vào element button trước combobox data (nhấn vào button thì hiển thị)
        )
      ) {
        // Thực hiện sự kiện tùy chỉnh:
        binding.value(event, el);
        // vnode.context[binding.expression](event); // vue 2
      }
    };
    document.body.addEventListener("click", el.clickOutsideEvent);
  },
  beforeUnmount: (el) => {
    document.body.removeEventListener("click", el.clickOutsideEvent);
  },
};

export default {
  directives: {
    clickoutside,
  },

  props: {
    placText: String,
    value: String,
    url: String,
    propValue: String,
    propText: String,
    isLoadData: {
      type: Boolean,
      default: true,
    },
  },
  methods: {
    saveItemFocus(index) {
      this.indexItemFocus = index;
    },
    hideListData() {
      this.isShowListData = false;
    },
    btnSelectDataOnClick() {
      this.isShowListData = !this.isShowListData;
    },

    itemOnSelect(item, index) {
      this.textInput = item[this.propText];
      this.indexItemSelected = index;
      this.isShowListData = false;
    },

    inputOnChange() {
      var me = this;
      // Thực hiện lọc các phần tử phù hợp trong data:
      this.dataFilter = this.data.filter((e) => {
        return e[me.propText].includes(me.text);
      });
      this.isShowListData = true;
    },
    selecItemUpDown() {
      var me = this;
      var keyCode = event.keyCode;
      var elToFocus = null;
      switch (keyCode) {
        case 27:
          this.isShowListData = false;
          break;
        case 40:
          this.isShowListData = true;
          elToFocus = this.$refs[`toFocus_${me.indexItemFocus + 1}`];
          if (
            this.indexItemFocus == null ||
            !elToFocus ||
            elToFocus.length == 0
          ) {
            this.indexItemFocus = 0;
          } else {
            this.indexItemFocus += 1;
          }
          break;
        case 38:
          this.isShowListData = true;
          elToFocus = this.$refs[`toFocus_${me.indexItemFocus - 1}`];
          if (
            this.indexItemFocus == null ||
            !elToFocus ||
            elToFocus.length == 0
          ) {
            this.indexItemFocus = this.dataFilter.length - 1;
          } else {
            this.indexItemFocus -= 1;
          }
          break;
        case 13:
          elToFocus = this.$refs[`toFocus_${me.indexItemFocus}`];
          if (elToFocus && elToFocus.length > 0) {
            elToFocus[0].click();
            this.isShowListData = false;
          }
          break;
        default:
          break;
      }
    },
  },
  created() {
    // Thực hiện lấy dữ liệu từ api:
    if (this.url) {
      fetch(this.url)
        .then((res) => res.json())
        .then((res) => {
          this.data = res;
          this.dataFilter = res;
        })
        .catch((res) => {
          console.log(res);
        });
    }
    
  },
  data() {
    return {
      textPlac: this.textInput,
      data: [],
      dataFilter: [],
      text: null,
      isShowListData: false,
      focus: false,
      indexItemFocus: null,
      indexItemSelected: null,
      maxIndexItemFocus: 0,
    };
  },
};
</script>
<style scoped>
.combobox {
  position: relative;
  /* flex-direction: row; */
  height: 30px;
  border: 1px solid #ccc;
  border-radius: 3px;
  align-items: center;
  justify-items: center;
}

.combobox__input,
select {
  height: 30px;
  flex: 1;
  padding-right: 56px !important;
  padding-left: 16px;
  outline: none;
  box-sizing: border-box;
  border: none;
}

.combobox__button {
  display: flex;
  align-items: center;
  justify-content: center;
  border-radius: 0 4px 4px 0;
  right: 0px;
  top: 0px;
  border: 1px solid #bbbbbb;
  border-left: unset;
  height: 30px;
  width: 37px;
  cursor: pointer;
  min-width: unset !important;
  outline: none;
  box-sizing: border-box;
  opacity: 0.5;
}
.button__icon {
  background-image: url("../../../assets//Sprites.64af8f61.svg");
  background-position: -560px -359px;
}

.combobox__button:hover,
.combobox__button:focus {
  background-color: #bbbbbb;
  color: #000;
}

.combobox__data {
  top: 35px !important;
  display: flex;
  flex-direction: column;
  padding: 4px 0px;
  position: absolute;
  width: 100%;
  top: 100%;
  left: 0;
  border-radius: 4px;
  background-color: #fff;
  box-shadow: 0px 3px 6px #00000016;
  z-index: 999;
}

.combobox__item {
  display: flex;
  align-items: center;
  justify-content: flex-start;
  line-height: 28px;
  padding-left: 10px;
  height: 28px;
  cursor: pointer;
  /* border: 1px solid #ccc; */
  outline: none;
}

.combobox__item-icon {
  width: 16px;
  height: 16px;
  font-size: 16px;
  margin-right: 10px;
  display: flex;
  align-items: center;
  justify-content: center;
}

.combobox__item-icon--selected {
  width: 14px;
  height: 11px;
}

.combobox__item:hover,
.combobox__item:focus,
.combobox__item--focus,
.combobox__item--hover {
  background-color: #e9ebee;
  color: #000;
}

.combobox__item--selected {
  pointer-events: none;
  background-color: #019160;
  color: #fff;
}
</style>