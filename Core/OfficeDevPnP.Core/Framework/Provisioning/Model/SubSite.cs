﻿using OfficeDevPnP.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeDevPnP.Core.Framework.Provisioning.Model
{
    public abstract partial class SubSite : BaseHierarchyModel, IEquatable<SubSite>
    {
        #region Private Members

        #endregion

        #region Constructors

        public SubSite()
        {
            this.Templates = new List<String>();
        }

        #endregion

        #region Public Members

        /// <summary>
        /// Defines if the Quick Launch is enabled or not
        /// </summary>
        public Boolean QuickLaunchEnabled { get; set; }

        /// <summary>
        /// Defines whether to use the same permissions of the parent site or not
        /// </summary>
        public Boolean UseSamePermissionsAsParentSite { get; set; }

        /// <summary>
        /// Title of the site
        /// </summary>
        public String Title { get; set; }

        /// <summary>
        /// Defines the Description for the Site
        /// </summary>
        public String Description { get; set; }

        /// <summary>
        /// Defines the list of Provisioning Templates to apply to the sub-site, if any
        /// </summary>
        public List<String> Templates { get; internal set; }

        #endregion

        #region Comparison code

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Returns HashCode</returns>
        public override int GetHashCode()
        {
            return (String.Format("{0}|{1}|{2}|{3}|{4}|",
                this.QuickLaunchEnabled.GetHashCode(),
                this.UseSamePermissionsAsParentSite.GetHashCode(),
                this.Title.GetHashCode(),
                this.Description.GetHashCode(),
                this.Templates.Aggregate(0, (acc, next) => acc += (next != null ? next.GetHashCode() : 0)),
                this.GetInheritedHashCode()
            ).GetHashCode());
        }

        /// <summary>
        /// Returns the HashCode of the members of any inherited type
        /// </summary>
        /// <returns></returns>
        protected abstract int GetInheritedHashCode();

        /// <summary>
        /// Compares object with SubSite
        /// </summary>
        /// <param name="obj">Object that represents SubSite</param>
        /// <returns>true if the current object is equal to the SubSite</returns>
        public override bool Equals(object obj)
        {
            if (!(obj is SubSite))
            {
                return (false);
            }
            return (Equals((SubSite)obj));
        }

        /// <summary>
        /// Compares SubSite object based on its properties
        /// </summary>
        /// <param name="other">SubSite object</param>
        /// <returns>true if the SubSite object is equal to the current object; otherwise, false.</returns>
        public bool Equals(SubSite other)
        {
            if (other == null)
            {
                return (false);
            }

            return (this.QuickLaunchEnabled == other.QuickLaunchEnabled &&
                this.UseSamePermissionsAsParentSite == other.UseSamePermissionsAsParentSite &&
                this.Title == other.Title &&
                this.Description == other.Description &&
                this.Templates.Intersect(other.Templates).Count() == 0 &&
                this.EqualsInherited(other)
                );
        }

        /// <summary>
        /// Returns the HashCode of the members of any inherited type
        /// </summary>
        /// <returns></returns>
        protected abstract bool EqualsInherited(SubSite other);

        #endregion
    }
}
