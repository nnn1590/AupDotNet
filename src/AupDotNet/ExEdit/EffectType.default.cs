using Karoterra.AupDotNet.ExEdit.Effects;

namespace Karoterra.AupDotNet.ExEdit
{
    public partial class EffectType
    {
        /// <summary>
        /// 組込みフィルタ効果の定義
        /// </summary>
        public static EffectType[] Defaults { get; } = new EffectType[]
        {
            VideoFileEffect.EffectType,
            ImageFileEffect.EffectType,
            AudioFileEffect.EffectType,
            TextEffect.EffectType,
            FigureEffect.EffectType,
            FrameBufferEffect.EffectType,
            WaveformEffect.EffectType,
            SceneEffect.EffectType,
            SceneAudioEffect.EffectType,
            PreviousObjectEffect.EffectType,
            StandardDrawEffect.EffectType,
            ExtendedDrawEffect.EffectType,
            StandardPlaybackEffect.EffectType,
            ParticleEffect.EffectType,
            SceneChangeEffect.EffectType,
            ColorCorrectionEffect.EffectType,
            ColorCorrectionFilterEffect.EffectType,
            ClippingEffect.EffectType,
            BlurEffect.EffectType,
            BorderBlurEffect.EffectType,
            BlurFilterEffect.EffectType,
            MosaicEffect.EffectType,
            MosaicFilterEffect.EffectType,
            EmissionEffect.EffectType,
            EmissionFilterEffect.EffectType,
            FlashEffect.EffectType,
            DiffuseEffect.EffectType,
            DiffuseFilterEffect.EffectType,
            GlowEffect.EffectType,
            GlowFilterEffect.EffectType,
            ChromaKeyEffect.EffectType,
            ColorKeyEffect.EffectType,
            LuminanceKeyEffect.EffectType,
            LightEffect.EffectType,
            ShadowEffect.EffectType,
            BorderEffect.EffectType,
            BevelEffect.EffectType,
            EdgeExtractionEffect.EffectType,
            SharpenEffect.EffectType,
            FadeEffect.EffectType,
            WipeEffect.EffectType,
            MaskEffect.EffectType,
            DiagonalClippingEffect.EffectType,
            RadialBlurEffect.EffectType,
            RadialBlurFilterEffect.EffectType,
            DirectionalBlurEffect.EffectType,
            DirectionalBlurFilterEffect.EffectType,
            LensBlurEffect.EffectType,
            LensBlurFilterEffect.EffectType,
            MotionBlurEffect.EffectType,
            MotionBlurFilterEffect.EffectType,
            PositionEffect.EffectType,
            ZoomEffect.EffectType,
            TransparencyEffect.EffectType,
            RotationEffect.EffectType,
            AreaExpansionEffect.EffectType,
            ResizeEffect.EffectType,
            Rotation90Effect.EffectType,
            VibrationEffect.EffectType,
            VibrationFilterEffect.EffectType,
            InversionEffect.EffectType,
            InversionFilterEffect.EffectType,
            MirrorEffect.EffectType,
            RasterEffect.EffectType,
            RasterFilterEffect.EffectType,
            RippleEffect.EffectType,
            ImageLoopEffect.EffectType,
            ImageLoopFilterEffect.EffectType,
            PolarTransformEffect.EffectType,
            DisplacementEffect.EffectType,
            NoiseEffect.EffectType,
            ColorShiftEffect.EffectType,
            ColorShiftFilterEffect.EffectType,
            MonochromaticEffect.EffectType,
            MonochromaticFilterEffect.EffectType,
            GradationEffect.EffectType,
            ColorSettingExEffect.EffectType,
            ColorSettingExFilterEffect.EffectType,
            GamutConversionEffect.EffectType,
            AnimationEffect.EffectType,
            CustomObjectEffect.EffectType,
            ScriptEffect.EffectType,
            VideoCompositionEffect.EffectType,
            ImageCompositionEffect.EffectType,
            DeinterlacingEffect.EffectType,
            CameraOptionEffect.EffectType,
            OffScreenEffect.EffectType,
            SplitEffect.EffectType,
            PartialFilterEffect.EffectType,
            AudioFadeEffect.EffectType,
            AudioDelayEffect.EffectType,
            AudioDelayFilterEffect.EffectType,
            MonauralEffect.EffectType,
            TimeControlEffect.EffectType,
            GroupControlEffect.EffectType,
            CameraControlEffect.EffectType,
            new EffectType(96, 0x45800400, 8, 2, 4, "カメラ制御(拡張描画)"),
            CameraEffect.EffectType,
            CameraShadowEffect.EffectType,
            CameraScriptEffect.EffectType,
            DenoiseFilterEffect.EffectType,
            SharpenFilterEffect.EffectType,
            BlurFilter2Effect.EffectType,
            ClipResizeFilterEffect.EffectType,
            FillBorderEffect.EffectType,
            ColorCorrection2Effect.EffectType,
            ColorCorrectionExEffect.EffectType,
            VolumeFilterEffect.EffectType,
        };
    }
}