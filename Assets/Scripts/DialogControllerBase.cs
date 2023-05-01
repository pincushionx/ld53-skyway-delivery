using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Windows;

namespace Pincushion.LD53
{
    public abstract class DialogControllerBase : MonoBehaviour
    {
        protected UIDocument _uiDocument;
        protected VisualElement _root;

        protected Action _onCloseCallback;
        protected InputController _input;

        bool isCoroutineRunning = false;

        protected void OnEnable()
        {
            _uiDocument = GetComponent<UIDocument>();
            _root = _uiDocument.rootVisualElement;
        }

        public virtual void Init(CityController city, InputController input, IMission mission, Action OnOkClicked)
        {
            _root.Q<TextElement>("MissionName").text = mission.Name;
            _root.Q<TextElement>("MissionText").text = mission.Text;
            _root.Q<TextElement>("PickupValue").text = city.SourcePlatforms[mission.SourcePlatformId].Name;
            _root.Q<TextElement>("DeliveryValue").text = city.DestinationPlatforms[mission.DestinationPlatformId].Name;

            // for the gamepad or if esc or similaris added to the keyboard
            input.OnConfirmPressed += OnConfirm;

            // save for later
            _onCloseCallback = OnOkClicked;
            _input = input;
        }

        protected void OnConfirm()
        {
            _input.OnConfirmPressed -= OnConfirm; // Clean this up, since init is actually a reinit

            if (!isCoroutineRunning)
            {
                if (gameObject.activeSelf)
                {
                    StartCoroutine(CloseCoroutine());
                }
                else
                {
                    Debug.LogError("The coroutine couldn't run because the game object is already disabled.");

                    // Cleanup tasks
                    isCoroutineRunning = true;
                    _onCloseCallback.Invoke();
                    isCoroutineRunning = false;
                }
            }
            else
            {
                Debug.LogError("The coroutine is already running");
            }
        }

        IEnumerator CloseCoroutine()
        {
            isCoroutineRunning = true;
            yield return null;

            float duration = 0.5f;
            float increment = 0.005f;
            Vector2 distPerIncrement = new Vector2(100, -100);

            Rect contentRect = _root.contentRect;
            float startingX = contentRect.x;
            float startingY = contentRect.y;

            for (int i = 0; i < 25; i++)
            {
                float x = startingX - i * distPerIncrement.x;
                float y = startingY - i * distPerIncrement.y;

                _root.style.top = y;
                _root.style.right = x;
                _root.MarkDirtyRepaint();

                yield return new WaitForEndOfFrame();
            }

            _onCloseCallback.Invoke();
            isCoroutineRunning = false;
        }
    }
}