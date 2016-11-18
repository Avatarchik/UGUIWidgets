﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

namespace Assets.src.GUI.ListView
{
	public class ListViewTest : MonoBehaviour {

		public InputField addContentInputField;
		public InputField deleteIndexInputField;

		private enum _Direction
		{
			None,
			Vertical,
			Horizontal,
		}

		private _Direction _direction;

		public Font TextFont;
		public Color TextColor;

		// Use this for initialization
		void Start () {
			this._start ();
		}

		private void _start() {
			string[] fontNames = Font.GetOSInstalledFontNames ();
			foreach (string fontName in fontNames) {
				//				Debug.Log (" @ ListViewTest: Font.GetOSInstalledFontNames(): " + fontName);
			}

			ListView listView = this.GetComponent<ListView> ();
			bool hasVertical = listView.direction == ListView.Direction.Vertical;
			bool hasHorizontal = listView.direction == ListView.Direction.Horizontal;

			if (hasVertical && !hasHorizontal) {
				this._direction = _Direction.Vertical;
			} else if(!hasVertical && hasHorizontal) {
				this._direction = _Direction.Horizontal;
			}

			string[] paragraphs = {
				"\u3000先帝创业未半而中道崩殂，今天下三分，益州疲弊，此诚危急存亡之秋也。然侍卫之臣不懈于内，忠志之士忘身于外者，盖追先帝之殊遇，欲报之于陛下也。诚宜开张圣听，以光先帝遗德，恢弘志士之气，不宜妄自菲薄，引喻失义，以塞忠谏之路也。 ",
				"\u3000宫中府中，俱为一体，陟罚臧否，不宜异同。若有作奸犯科及为忠善者，宜付有司论其刑赏，以昭陛下平明之理，不宜偏私，使内外异法也。 ",
				"\u3000侍中侍郎郭攸之、费祎、董允等，此皆良实，志虑忠纯，是以先帝简拔以遗陛下。愚以为宫中之事，事无大小，悉以咨之，然后施行，必能裨补阙漏，有所广益。 ",
				"\u3000将军向宠，性行淑均，晓畅军事，试用于昔日，先帝称之曰能，是以众议举宠为督。愚以为营中之事，悉以咨之，必能使行阵和睦，优劣得所。 ",
				"\u3000亲贤臣，远小人，此先汉所以兴隆也；亲小人，远贤臣，此后汉所以倾颓也。先帝在时，每与臣论此事，未尝不叹息痛恨于桓、灵也。侍中、尚书、长史、参军，此悉贞良死节之臣，愿陛下亲之信之，则汉室之隆，可计日而待也。 ",
				"\u3000臣本布衣，躬耕于南阳，苟全性命于乱世，不求闻达于诸侯。先帝不以臣卑鄙，猥自枉屈，三顾臣于草庐之中，咨臣以当世之事，由是感激，遂许先帝以驱驰。后值倾覆，受任于败军之际，奉命于危难之间，尔来二十有一年矣。 ",
				"\u3000先帝知臣谨慎，故临崩寄臣以大事也。受命以来，夙夜忧叹，恐托付不效，以伤先帝之明，故五月渡泸，深入不毛。今南方已定，兵甲已足，当奖率三军，北定中原，庶竭驽钝，攘除奸凶，兴复汉室，还于旧都。此臣所以报先帝而忠陛下之职分也。至于斟酌损益，进尽忠言，则攸之、祎、允之任也。 ",
				"\u3000愿陛下托臣以讨贼兴复之效，不效则治臣之罪，以告先帝之灵。若无兴德之言，则责攸之、祎、允等之慢，以彰其咎；陛下亦宜自谋，以咨诹善道，察纳雅言，深追先帝遗诏。臣不胜受恩感激。 ",
				"\u3000今当远离，临表涕零，不知所言。 ",
			};

			foreach (string paragraph in paragraphs) {
				this._addItem (paragraph);
			}

		}

		// Update is called once per frame
		void Update () {

		}

		private void _addItem(string text) {
			GameObject textObj = new GameObject ();

			RectTransform rectTransformComponent = textObj.AddComponent<RectTransform> ();

			Text textComponent = textObj.AddComponent<Text> ();
			switch (this._direction) {
			case _Direction.Vertical:
				{
					textComponent.horizontalOverflow = HorizontalWrapMode.Wrap;
					textComponent.verticalOverflow = VerticalWrapMode.Truncate;
					break;
				}
			case _Direction.Horizontal:
				{
					textComponent.horizontalOverflow = HorizontalWrapMode.Wrap;
					textComponent.verticalOverflow = VerticalWrapMode.Truncate;
					break;
				}
			}

			textComponent.color = this.TextColor;
			textComponent.font = this.TextFont;
			textComponent.text = text;

			this.GetComponent<ListView> () .AddItem(textObj);
			rectTransformComponent.anchorMin = Vector2.zero;
			rectTransformComponent.anchorMax = Vector2.one;
			rectTransformComponent.offsetMin = Vector2.zero;
			rectTransformComponent.offsetMax = Vector2.zero;
		}

		public void AddContent() {
			string contentText = this.addContentInputField.text;
			this._addItem (contentText);
		}

		public void DeleteIndex() {
			int deleteIndex = System.Int32.Parse (this.deleteIndexInputField.text);
			ListView listView = this.GetComponent<ListView> ();
			GameObject item = listView.GetItem (deleteIndex);
			listView.RemoveItem(deleteIndex);
			Destroy (item);
		}
	}
}


