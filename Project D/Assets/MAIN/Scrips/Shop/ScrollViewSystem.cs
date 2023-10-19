using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScrollViewSystem : MonoBehaviour
{
    private ScrollRect scrollRect;

    [SerializeField] private Button leftButton;
    [SerializeField] private Button rightButton;
    [SerializeField] private float scrollDistance = 100f; // Khoảng cách di chuyển

    private float targetPosition = 0f; // Vị trí đích khi di chuyển
    private float startPosition = 0f; // Vị trí ban đầu
    private bool isScrolling = false; // Đang di chuyển hay không

    private void Start()
    {
        scrollRect = GetComponent<ScrollRect>();

        leftButton.onClick.AddListener(ScrollLeft);
        rightButton.onClick.AddListener(ScrollRight);

        scrollRect.onValueChanged.AddListener(OnScrollValueChanged);
    }

    private void OnScrollValueChanged(Vector2 normalizedPosition)
    {
        leftButton.gameObject.SetActive(CanScrollLeft());
        rightButton.gameObject.SetActive(CanScrollRight());
    }

    private bool CanScrollLeft()
    {
        return scrollRect.horizontalNormalizedPosition > 0f;
    }

    private bool CanScrollRight()
    {
        return scrollRect.horizontalNormalizedPosition < 1f;
    }

    private void Update()
    {
        if (isScrolling)
        {
            float currentPosition = scrollRect.horizontalNormalizedPosition * scrollRect.content.rect.width;

            // Di chuyển Scroll View tới vị trí đích
            if (Mathf.Abs(currentPosition - targetPosition) > 1f)
            {
                float newPosition = Mathf.Lerp(currentPosition, targetPosition, Time.deltaTime * 10f) / scrollRect.content.rect.width;
                scrollRect.horizontalNormalizedPosition = newPosition;
            }
            else
            {
                // Dừng di chuyển khi đã đạt tới vị trí đích
                scrollRect.horizontalNormalizedPosition = targetPosition / scrollRect.content.rect.width;
                isScrolling = false;

                // Kiểm tra vị trí cuối cùng của nút cuộn
                if (!CanScrollLeft())
                {
                    leftButton.gameObject.SetActive(false);
                }
                if (!CanScrollRight())
                {
                    rightButton.gameObject.SetActive(false);
                }
            }
        }
    }

    private void ScrollLeft()
    {
        if (!isScrolling && CanScrollLeft())
        {
            startPosition = scrollRect.horizontalNormalizedPosition * scrollRect.content.rect.width;
            targetPosition = Mathf.Clamp(startPosition - scrollDistance, 0f, scrollRect.content.rect.width);
            isScrolling = true;
        }
    }

    private void ScrollRight()
    {
        if (!isScrolling && CanScrollRight())
        {
            startPosition = scrollRect.horizontalNormalizedPosition * scrollRect.content.rect.width;
            targetPosition = Mathf.Clamp(startPosition + scrollDistance, 0f, scrollRect.content.rect.width);
            isScrolling = true;
        }
    }

}
