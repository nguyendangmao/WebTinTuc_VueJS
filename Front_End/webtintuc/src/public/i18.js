import { createI18n } from 'vue-i18n'

var i18n = createI18n({
    locale: 'vi',
    messages: {
        vi: {
            ID: 'ID',
            Name: 'Tên',  
            More: 'Chức năng',
            Tabindex:'Thứ tự hiển thị',
            DateUpdate:'Ngày sửa gần nhất',
            AccUpdate:'Người sửa gần nhất',
        }
    }
})
export default i18n
