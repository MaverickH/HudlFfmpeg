﻿using System;
using Hudl.Ffmpeg.BaseTypes;
using Hudl.Ffmpeg.Common;
using Hudl.Ffmpeg.Resources.BaseTypes;
using Hudl.Ffmpeg.Settings.BaseTypes;

namespace Hudl.Ffmpeg.Settings
{
    /// <summary>
    /// Sets the quantizer scale for the encoder on a scale between 0-51: where 0 is lossless and 51 is the worst possible. 18 is visually lossless quality
    /// </summary>
    [AppliesToResource(Type = typeof(IAudio))]
    [AppliesToResource(Type = typeof(IVideo))]
    [SettingsApplication(PreDeclaration = true, ResourceType = SettingsCollectionResourceType.Output)]
    public class ConstantRateFactor : BaseSetting
    {
        private const string SettingType = "-crf";

        public ConstantRateFactor(int quantizerScale)
            : base(SettingType)
        {
            QuantizerScale = quantizerScale;
        }
    
        public double QuantizerScale { get; set; }

        public override string ToString()
        {
            if (QuantizerScale < 0 || QuantizerScale > 51)
            {
                throw new InvalidOperationException("QuantizerScale size must be between 0 - 51.");
            }

            return string.Concat(Type, " ", QuantizerScale);
        }
    }
}