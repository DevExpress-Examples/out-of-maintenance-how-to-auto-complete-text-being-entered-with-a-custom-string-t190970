using System;
using DevExpress.Data.Mask;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Mask;

namespace AutoCompleteMaskManager
{
    [System.ComponentModel.DesignerCategory("")]
    public class MyTextEditWithCustomAutocomplete : TextEdit
    {
        protected override MaskManager CreateMaskManager(MaskProperties mask)
        {
            MaskManager maskManager;
            if (mask.MaskType == MaskType.Custom)
                maskManager = new MyAutoCompleteMaskManager(new CustomMaskManagerCommon(new MaskManagerPlainTextState(string.Empty, 0, 0)));
            else
                maskManager = base.CreateMaskManager(mask);
            return maskManager;
        }
    }
}
