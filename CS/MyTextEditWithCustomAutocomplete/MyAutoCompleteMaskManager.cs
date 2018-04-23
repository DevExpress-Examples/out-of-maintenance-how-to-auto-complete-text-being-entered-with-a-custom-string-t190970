using System;
using DevExpress.Data.Mask;

namespace AutoCompleteMaskManager {
    public class MyAutoCompleteMaskManager : MaskManagerSelectAllEnhancer<MaskManagerCommon<MaskManagerPlainTextState>> {
        public MyAutoCompleteMaskManager(MaskManagerCommon<MaskManagerPlainTextState> nested)
            : base(nested) {
        }
    }
}
