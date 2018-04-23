using System;
using DevExpress.Data.Mask;

namespace AutoCompleteMaskManager {
    public class CustomMaskManagerCommon : MaskManagerCommon<MaskManagerPlainTextState> {
        public CustomMaskManagerCommon(MaskManagerPlainTextState initialState)
            : base(initialState) {
        }


        protected override MaskManagerPlainTextState CreateStateForApply(string editText, int cursorPosition, int selectionAnchor) {
            return new MaskManagerPlainTextState(editText, cursorPosition, selectionAnchor);
        }

        protected override MaskManagerPlainTextState GetEmptyState() {
            return MaskManagerPlainTextState.Empty;
        }

        protected override int GetCursorPosition(MaskManagerPlainTextState state) {
            return state.CursorPosition;
        }

        protected override string GetDisplayText(MaskManagerPlainTextState state) {
            string editText = GetEditText(state);
            return editText;
        }

        protected override string GetEditText(MaskManagerPlainTextState state) {
            return state.EditText;
        }

        protected override int GetSelectionAnchor(MaskManagerPlainTextState state) {
            return state.SelectionAnchor;
        }

        public override bool Backspace() {
            if (IsSelection) {
                return Insert(string.Empty);
            }
            string head = GetCurrentEditText().Substring(0, DisplayCursorPosition);
            string tail = GetCurrentEditText().Substring(DisplayCursorPosition);
            if (head.Length < 1) {
                return false;
            }
            return Apply(new MaskManagerPlainTextState(head.Substring(0, head.Length - 1) + tail, DisplayCursorPosition - 1, DisplayCursorPosition - 1), StateChangeType.Delete);
        }

        public override bool Delete() {
            if (IsSelection) {
                return Insert(string.Empty);
            }
            string head = GetCurrentEditText().Substring(0, DisplayCursorPosition);
            string tail = GetCurrentEditText().Substring(DisplayCursorPosition);
            if (tail.Length < 1) {
                return false;
            }
            return Apply(new MaskManagerPlainTextState(head + tail.Substring(1), DisplayCursorPosition, DisplayCursorPosition), StateChangeType.Delete);
        }

        public override bool Insert(string insertion) {
            StateChangeType changeType = (insertion.Length == 0 && IsSelection) ? StateChangeType.Delete : StateChangeType.Insert;

            string head = GetCurrentEditText().Substring(0, DisplaySelectionStart);

            string tail = GetCurrentEditText().Substring(DisplaySelectionEnd);

            string newText = head + insertion + tail;


            const string SampleAutocompleteText = "_SampleAutocompleteText";


            if (changeType == StateChangeType.Insert && tail.Length == 0 && insertion.Length == 1) {
                string autocompletedText = newText + SampleAutocompleteText;

                return Apply(new MaskManagerPlainTextState(autocompletedText, newText.Length, autocompletedText.Length), changeType);
            } else {
                int cursorPosition = (head + insertion).Length;
                return Apply(new MaskManagerPlainTextState(newText, cursorPosition, cursorPosition), changeType);
            }
        }

        public override void SelectAll() {
            CursorEnd(false);
            CursorHome(true);
        }
    }
}
