<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl">

	<xsl:output method="text" indent="yes" />
	<xsl:param name="Grad"></xsl:param>
	<xsl:param name="RGB"></xsl:param>
	<xsl:template match="/">

		<html>

			<head>

				<style type="text/css">
					body {
					font-size:0.8em;
					font-family: Arial;
					}

					h1, h2 {
					font-size:0.9em;
					}

					.currentGrade {
					width:100%;
					height:20px;
					background-color:#<xsl:value-of select="$RGB"/>;
					}
				</style>

			</head>


			<body>
				<xsl:for-each select="CCDWerteSystem/Grad[@farbe=$Grad]">

					<h1>
						Aktueller Grad: <xsl:value-of select="@farbe"/>
					</h1>

					<div class="currentGrade">
						&#160;
					</div>

					<xsl:if test="count(Prinzipien/Prinzip) &gt; 0">
						<h2>Prinzipien</h2>
						<ul>
							<xsl:for-each select="Prinzipien/Prinzip">
								<li>
									<a href="{@href}" target="_blank">
										<xsl:value-of select="@titel"/>
									</a>
								</li>
							</xsl:for-each>
						</ul>
					</xsl:if>	
						
					<xsl:if test="count(Regeln/Regel) &gt; 0">
						<h2>Regeln</h2>
						<ul>
							<xsl:for-each select="Regeln/Regel">
								<li>
									<a href="{@href}" target="_blank">
										<xsl:value-of select="@titel"/>
									</a>
								</li>
							</xsl:for-each>
						</ul>
					</xsl:if>

					<xsl:if test="count(Praktiken/Praktik) &gt; 0">
						<h2>Praktiken</h2>
						<ul>
							<xsl:for-each select="Praktiken/Praktik">
								<li>
									<a href="{@href}" target="_blank">
										<xsl:value-of select="@titel"/>
									</a>
								</li>
							</xsl:for-each>
						</ul>
					</xsl:if>	
						
				</xsl:for-each>

			</body>
		</html>


	</xsl:template>
</xsl:stylesheet>
