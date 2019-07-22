using UnityEngine;

namespace UnityDynamicScrollRect
{
    public interface IScrollItem
    {
        void reset();
        int currentIndex { get; set; }
		RectTransform rectTransform { get; }
    }
}