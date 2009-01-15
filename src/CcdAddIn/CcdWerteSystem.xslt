<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>

    <xsl:output method="xml" indent="yes"/>
    <xsl:template match="/">

		<html>
			<body>
				<table border="0">
					<xsl:for-each select="CCDWerteSystem/Grad">
						<tr>
							<td>
								<xsl:value-of select="@farbe"/>

								<h4>Prinzipien</h4>
								<ul>
									<xsl:for-each select="Prinzipien/Prinzip">
										<li>
											<a href="{@href}" target="_blank"><xsl:value-of select="@titel"/></a>
										</li>
									</xsl:for-each>
								</ul>
								<h4>Regeln</h4>
								<xsl:for-each select="Regeln/Regel">
									<xsl:value-of select="@titel"/>
									<br/>
								</xsl:for-each>
								<h4>Praktiken</h4>
								<xsl:for-each select="Praktiken/Praktik">
									<xsl:value-of select="@titel"/>
									<br/>
								</xsl:for-each>
							</td>
						</tr>
					</xsl:for-each>
				</table>
			</body>
		</html>


	</xsl:template>
</xsl:stylesheet>
